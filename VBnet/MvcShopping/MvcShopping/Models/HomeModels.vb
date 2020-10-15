Namespace MvcShopping.Models

    ''' <summary>
    ''' 商品情報のモデルクラス
    ''' </summary>
    Public Class ProductModel
        ' 商品リスト
        '   C#の場合
        '   Public IQueryable<TProduct> Products ( Get; Set; )
        Public Property Products As IQueryable(Of TProduct)

        ' カレントページ
        Public Property CurrentPage As Integer
        ' 前ページがあるか
        Public Property HasPrevPage As Boolean
        ' 次ページがあるか
        Public Property HasNextPage As Boolean

    End Class

End Namespace