@ModelType MvcShopping.MvcShopping.Models.ProductItemModel
@Code
    ViewData("Title") = "日経ＢＰショッピング - " & Model.Product.name
End Code

<h2>@Model.Product.name</h2>
<p>
    <img src="/Images/@(Model.Product.id).jpg" alt="" /><br />
    商品ＩＤ：@Model.Product.id<br />
    価格：@Model.Product.price<br />
    評価情報：@Model.ProductDetail.description<br />
    @If User.Identity.IsAuthenticated Then
        @<text>買う</text>
    End If
</p>

@Html.ActionLink("戻る", "/")
