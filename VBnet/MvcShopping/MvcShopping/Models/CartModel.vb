''' <summary>
''' カートのモデルクラス
''' </summary>
Public Class CartModel

    ' 商品コレクション
    Public Property Items As List(Of CartItem)

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    Sub New()
        Me.Items = New List(Of CartItem)()
    End Sub

    ' 編集中の商品ＩＤ
    Public Property EditID As String

End Class

''' <summary>
''' カートの商品クラス
''' </summary>
Public Class CartItem

    ' 商品ＩＤ
    Public Property ID As String
    ' 商品名
    Public Property Name As String
    ' 商品の単価
    Public Property Price As Integer
    ' 購入する商品数
    Public Property Count As Integer

End Class
