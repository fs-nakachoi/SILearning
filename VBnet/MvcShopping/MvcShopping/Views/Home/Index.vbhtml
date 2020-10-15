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
        <ul>
            @For Each item In Model.Categories
                @<li>
                    @Html.ActionLink(item.name, "/", New With {.category = item.id})
                </li>
            Next
        </ul>
        <p>

            @For Each item In Model.Products

                @<table align="left">
                    <tr>
                        <td align="center">
                            <img src="/Images/@(item.id).jpg" alt="" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            @*@item.name*@
                            @Html.ActionLink(item.name, "Item/", New With {item.id})
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            @String.Format("{0:#,### 円}", item.price)
                        </td>
                    </tr>
                    @if User.Identity.IsAuthenticated Then
                        @<tr>
                            <td align = "center" > 買う</td>
                        </tr>
                    End If
                </table>

            Next
            <br clear="left" />

        </p>

        @If Model.HasPrevPage Then
            @Html.ActionLink("前頁", "/", New With {.Page = Model.CurrentPage - 1, .category = Model.Category})
        Else
            @<text>前頁</text>
        End If

        @If Model.HasNextPage Then
            @Html.ActionLink("次頁", "/", New With {.Page = Model.CurrentPage + 1, .category = Model.Category})
        Else
            @<text>次頁</text>
        End If
    </div>
</div>
