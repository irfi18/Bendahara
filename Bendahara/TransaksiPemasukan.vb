Imports MySql.Data.MySqlClient

Public Class TransaksiPemasukan

    Private Sub Transaksi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'TransaksiMasuk1.SetParameterValue("StartDate", Format(DateTimePicker1.Value, "dd/MM/yyyy"))
        'TransaksiMasuk1.SetParameterValue("EndDate", Format(DateTimePicker2.Value, "dd/MM/yyyy"))
        'CrystalReportViewer1.Refresh()
        Dim Laporan As New TransaksiMasuk
        CrystalReportViewer1.ReportSource = Laporan
        CrystalReportViewer1.SelectionFormula = "{pemasukan1.tanggal}>=Date('" & DateTimePicker1.Value & "') And {pemasukan1.tanggal}<=Date('" & DateTimePicker2.Value & "')"
        CrystalReportViewer1.Refresh()
        CrystalReportViewer1.Show()

    End Sub
End Class