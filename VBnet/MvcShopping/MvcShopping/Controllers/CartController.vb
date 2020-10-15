Imports System.Configuration
Imports System.Data.Linq
Imports System.Web.Mvc
Imports MvcShopping.MvcShopping.Models

Namespace Controllers

    Public Class CartController
        Inherits Controller

        ' GET: Cart
        Function Index() As ActionResult
            ' セッション内容を表示
            Dim model As CartModel = Session("Cart")
            ' セッションが空だったら
            If IsNothing(model) Then
                model = New CartModel()
            End If

            Return View(model)
        End Function

        ''' <summary>
        ''' GET: /Cart/AddItem
        ''' </summary>
        ''' <param name="id">商品ID</param>
        ''' <param name="count">商品数</param>
        ''' <returns></returns>
        <Authorize>
        Function AddItem(ByVal id As String, ByVal count? As Integer) As ActionResult

            ' セッション情報からカートのモデルを取得する
            Dim model As CartModel = Session("Cart")
            If IsNothing(model) Then
                model = New CartModel()
            End If

            ' web.configから接続文字列を取得
            Dim cnstr As String = ConfigurationManager.ConnectionStrings("mvcdbConnectionString").ConnectionString

            ' データベースに接続する
            Dim dc As New DataContext(cnstr)

            ' 商品情報を取得
            Dim product = (From t In dc.GetTable(Of TProduct)() _
                                  .Where(Function(t) t.id = id)
                           Select t).Single()

            ' カートの商品アイテムを作成
            Dim Item As CartItem = New CartItem()
            Item.ID = id
            Item.Name = product.name
            Item.Price = product.price
            If IsNothing(count) Then Item.Count = 1 Else Item.Count = count

            'モデルに追加する
            model.Items.Add(Item)

            ' セッションに保存する
            Session("Cart") = model

            ' カートのページを表示する
            Return RedirectToAction("Index")

        End Function

    End Class

End Namespace