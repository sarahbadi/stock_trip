Partial Class DataSet2
    Partial Class tgddDataTable

        Private Sub tgddDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.StottColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

        Private Sub tgddDataTable_tgddRowChanging(ByVal sender As System.Object, ByVal e As tgddRowChangeEvent) Handles Me.tgddRowChanging

        End Sub

    End Class

    Partial Class msrofat_1DataTable

        Private Sub msrofat_1DataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.balanceColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class

Namespace DataSet2TableAdapters
    
    Partial Public Class ksf_salTableAdapter
    End Class
End Namespace
