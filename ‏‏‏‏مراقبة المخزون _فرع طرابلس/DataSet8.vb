Partial Class DataSet8
    Partial Class card_n1DataTable

       

    End Class

    Partial Class msrofattDataTable

        Private Sub msrofattDataTable_ColumnChanging(ByVal sender As System.Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.no_sColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

    Partial Class V_TranRIostaDataTable

        Private Sub V_TranRIostaDataTable_V_TranRIostaRowChanging(ByVal sender As System.Object, ByVal e As V_TranRIostaRowChangeEvent) Handles Me.V_TranRIostaRowChanging

        End Sub

    End Class

End Class

Namespace DataSet8TableAdapters
    
    Partial Public Class card_nTableAdapter
    End Class
End Namespace
