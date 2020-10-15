Imports System.Configuration
Imports System.Data.Linq
Imports MvcShopping.MvcShopping.Models

Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index(ByVal page? As Integer, ByVal category? As Integer) As ActionResult
        Dim cnstr As String

        ' Web.configから接続文字列を取得
        cnstr = ConfigurationManager.ConnectionStrings("mvcdbConnectionString").ConnectionString

        ' データベースに接続する
        Dim dc As New DataContext(cnstr)

        ' 商品一覧を取得
        Dim model As New ProductModel()
        model.Products = dc.GetTable(Of TProduct)

        ' カテゴリ一覧を取得
        ' model.Categories = dc.GetTable(Of TCategory).OrderBy(Function(c) c.id)
        Dim categories As IQueryable(Of TCategory) = Session("categories")
        If IsNothing(categories) Then
            categories = dc.GetTable(Of TCategory).OrderBy(Function(c) c.id)
            Session("categories") = categories
        End If
        model.Categories = categories

        ' １ページに表示する商品数
        Dim max_item As Integer = 5
        ' 表示中のページ
        Dim cur_page As Integer
        Dim max As Integer = 0

        ' カテゴリが指定されていな場合
        If IsNothing(category) Then

            ' 指定ページの商品数を取得する
            model.Products = (From p In dc.GetTable(Of TProduct)()
                              Select p).Skip(cur_page * max_item).Take(max_item)

            ' 商品数
            max = dc.GetTable(Of TProduct).Count()

        Else

            ' 指定したカテゴリ内の商品を取得
            model.Products = (From p In dc.GetTable(Of TProduct)() _
                                  .Where(Function(p) p.cateid = category)
                              Select p).Skip(cur_page * max_item).Take(max_item)

            ' 商品数
            max = (From p In dc.GetTable(Of TProduct)() _
                  .Where(Function(p) p.cateid = category)
                   Select p).Count()

        End If

        ' カテゴリ指定
        model.Category = category

        ' ページ指定がされていない場合
        If IsNothing(page) Then
            cur_page = 0
        Else
            cur_page = page
        End If

        ' カレントページの指定
        model.CurrentPage = cur_page
        ' 前頁が存在するか
        If (cur_page = 0) Then
            model.HasPrevPage = False
        Else
            model.HasPrevPage = True
        End If
        ' 次頁が存在するか
        If (cur_page * max_item + max_item < max) Then
            model.HasNextPage = True
        Else
            model.HasNextPage = False
        End If

        ' モデルを設定する
        Return View(model)
    End Function

    Function About() As ActionResult
        ViewData("Message") = "Your application description page."

        Return View()
    End Function

    Function Contact() As ActionResult
        ViewData("Message") = "Your contact page."

        Return View()
    End Function
End Class
