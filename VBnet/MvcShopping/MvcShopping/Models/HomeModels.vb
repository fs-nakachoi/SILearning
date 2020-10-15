Namespace MvcShopping.Models

    ''' <summary>
    ''' 商品情報のモデルクラス
    ''' </summary>
    Public Class ProductModel
        ' 商品リスト
        Public Property Products As IQueryable(Of TProduct)
        ' カテゴリ
        Public Property Categories As IQueryable(Of TCategory)

        ' カレントページ
        Public Property CurrentPage As Integer
        ' 前ページがあるか
        Public Property HasPrevPage As Boolean
        ' 次ページがあるか
        Public Property HasNextPage As Boolean
        ' カテゴリID
        Public Property Category As Integer?

    End Class

End Namespace