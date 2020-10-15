@Imports Microsoft.AspNet.Identity

@If Request.IsAuthenticated Then
    @Using Html.BeginForm("LogOff", "Account", FormMethod.Post, New With {.id = "logoutForm", .class = "navbar-right"})
    @Html.AntiForgeryToken()
    @<ul class="nav navbar-nav navbar-right">
    @*<li class="LOGINSTAT">ログオン状態</li>*@
    <li  class="MYPAGE">【マイページ】</li>
    <li>
        @Html.ActionLink("Hello " + User.Identity.GetUserName() + "!", "Index", "Manage", routeValues:=Nothing, htmlAttributes:=New With {.title = "Manage"})
    </li>
    <li><a href="javascript:document.getElementById('logoutForm').submit()">ログオフ</a></li>
</ul>
    End Using
Else
    @<ul class="nav navbar-nav navbar-right">
    @*<li class="LOGINSTAT">未ログオン</li>*@
    <li>@Html.ActionLink("登録", "Register", "Account", routeValues:=Nothing, htmlAttributes:=New With {.id = "registerLink"})</li>
    <li>@Html.ActionLink("ログイン", "Login", "Account", routeValues:=Nothing, htmlAttributes:=New With {.id = "loginLink"})</li>
</ul>
End If

