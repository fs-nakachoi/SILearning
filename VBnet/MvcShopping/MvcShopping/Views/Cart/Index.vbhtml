@ModelType MvcShopping.CartModel
@Code
    ViewData("Title") = "日経BPショッピング - カート"
End Code

<h2>ショッピングカート</h2>

<p>
    @Html.ActionLink("Create New", "Create")
</p>

@Using Html.BeginForm("UpdateItem", "Cart")
@<table class="table">
    <tr>
        <th>商品ID</th>
        <th>商品名</th>
        <th>価格</th>
        <th>数量</th>
    </tr>

    @For Each item In Model.Items
        @<tr>
            <td>@item.id</td>
            <td>@item.Name</td>
            <td>@item.Price</td>
            @If IsNothing(Model.EditID) Then
                @<td>@item.Count</td>
                @<td>@Html.ActionLink("編集", "EditItem", New With {item.ID})</td>
                @<td>@Html.ActionLink("削除", "RemoveItem", New With {item.ID})</td>
            ElseIf Model.EditID = item.ID Then
                @<td>@Html.TextBox("Count", item.Count)</td>
                @<td><input type="submit" value="更新"/></td>
                @<td>@Html.ActionLink("キャンセル", "CancelItem", New With {item.ID})</td>
            Else
                @<td>@item.Count</td>
            End If
        </tr>
    Next

</table>
End Using

@Html.ActionLink("戻る", "", "Home")