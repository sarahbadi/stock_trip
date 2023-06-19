

Partial Public Class DataSet7
    Partial Class stockmDataTable

        Private Sub stockmDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.balanceColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class

Namespace DataSet7TableAdapters
    
    Partial Public Class returnsTableAdapter
    End Class
End Namespace
