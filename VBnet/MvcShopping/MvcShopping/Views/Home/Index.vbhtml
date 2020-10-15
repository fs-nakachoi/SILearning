@inherits System.Web.Mvc.WebViewPage(Of ProductModel)
@Imports MvcShopping.MvcShopping.Models

@Code
    ViewData("Title") = "日経BPショッピング"
End Code

<div class="jumbotron">
    <h1>日経BPショッピング</h1>
</div>

<div class="row">
    <div>
        <h2>商品一覧</h2>
        <p>
            @* コメントアウト
                @For i As Integer = 1 To 10
                    WriteLiteral(String.Format("商品その{0}</br>", i))
                Next
            *@


            @For Each item In Model.Products
                @* WriteLiteral(String.Format("商品名 {0}</br>", item.name)) *@
                @* @<text>商品名 </text> @item.name @<br> *@
                @*
                    @<p>
                        <text>商品名 </text> @item.name
                        <text>価格 </text> @item.price
                        <img src="/Images/@(item.id).jpg" alt="" />
                    </p>
                *@

                @<table align="left">
                    <tr>
                        <td align="center">
                            <img src="/Images/@(item.id).jpg" alt="" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            @item.name
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            @String.Format("{0:#,### 円}", item.price)
                        </td>
                    </tr>
                </table>

            Next
            <br clear="left" />

        </p>

        @If Model.HasPrevPage Then
            @Html.ActionLink("前頁", "/", New With {.Page = Model.CurrentPage - 1})
        Else
            @<text>前頁</text>
        End If

        @If Model.HasNextPage Then
            @Html.ActionLink("次頁", "/", New With {.Page = Model.CurrentPage + 1})
        Else
            @<text>次頁</text>
        End If
    </div>
</div>
