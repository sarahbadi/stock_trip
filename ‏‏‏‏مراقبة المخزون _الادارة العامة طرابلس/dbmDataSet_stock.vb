Partial Class dbmDataSet_stock
    Partial Class View_stockDataTable

        Private Sub View_stockDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.qun_totColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class
