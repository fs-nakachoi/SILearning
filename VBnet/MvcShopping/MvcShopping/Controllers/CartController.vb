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
        ''' <summary>
        ''' GET: /Cart/RemoveItem
        ''' </summary>
        ''' <param name="id">商品ＩＤ</param>
        ''' <returns></returns>
        <Authorize>
        Function RemoveItem(ByVal id As String) As ActionResult

            ' セッション情報からカートのモデルを取得する
            Dim model As CartModel = Session("Cart")

            ' 指定された商品ＩＤをカートから削除
            For Each item In model.Items
                If item.ID = id Then
                    model.Items.Remove(item)
                    Exit For
                End If
            Next

            ' カートのページを表示する
            Return RedirectToAction("Index")

        End Function

        ''' <summary>
        ''' GET: /Cart/EditItem
        ''' </summary>
        ''' <param name="id">商品ＩＤ</param>
        ''' <returns></returns>
        <Authorize>
        Function EditItem(ByVal id As String) As ActionResult

            ' セッション情報からカートのモデルを取得する
            Dim model As CartModel = Session("Cart")

            ' 編集中のＩＤを設定
            model.EditID = id

            ' カートのページを表示する
            Return RedirectToAction("Index")

        End Function

        ''' <summary>
        ''' GET: /Cart/UpdateItem
        ''' </summary>
        ''' <returns></returns>
        <Authorize>
        Function UpdateItem() As ActionResult

            ' セッション情報からカートのモデルを取得する
            Dim model As CartModel = Session("Cart")

            ' 変更した数量を取得
            Dim id As String = model.EditID
            Dim count As Integer = Integer.Parse(Request.Form("Count"))

            ' 編集中のＩＤの数量を変更
            Dim item = (From t In model.Items _
                                  .Where(Function(t) t.ID = id)
                        Select t)
            item.Single().Count = count
            ' 編集中のＩＤにNULLを設定
            model.EditID = Nothing

            ' カートのページを表示する
            Return RedirectToAction("Index")

        End Function

        ''' <summary>
        ''' GET: /Cart/CancelItem
        ''' </summary>
        ''' <returns></returns>
        <Authorize>
        Function CancelItem() As ActionResult

            ' セッション情報からカートのモデルを取得する
            Dim model As CartModel = Session("Cart")

            ' 編集中のＩＤをキャンセル
            model.EditID = Nothing

            ' カートのページを表示する
            Return RedirectToAction("Index")

        End Function

    End Class

End Namespace