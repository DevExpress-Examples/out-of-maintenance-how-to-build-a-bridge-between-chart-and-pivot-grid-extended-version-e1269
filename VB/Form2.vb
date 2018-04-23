Imports Microsoft.VisualBasic
Imports System
Imports System.Data
Imports System.Windows.Forms
Imports System.ComponentModel

Namespace ChartPivotInteractionApproaches
	Partial Public Class Form2
		Inherits Form
		Private browsableTable_Renamed As DataTable

		Public Property BrowsableTable() As DataTable
			Get
				Return browsableTable_Renamed
			End Get
			Set(ByVal value As DataTable)
				browsableTable_Renamed = value
				dataGridView1.DataSource = value
				RecalculateActualWidth()
			End Set
		End Property

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub dataGridView1_ColumnWidthChanged(ByVal sender As Object, ByVal e As DataGridViewColumnEventArgs) Handles dataGridView1.ColumnWidthChanged
			RecalculateActualWidth()
		End Sub

		Private Sub dataGridView1_RowHeadersWidthChanged(ByVal sender As Object, ByVal e As EventArgs) Handles dataGridView1.RowHeadersWidthChanged
			RecalculateActualWidth()
		End Sub

		Private Sub RecalculateActualWidth()
			Dim totalWidth As Integer = 0

			For Each col As DataGridViewColumn In dataGridView1.Columns
				totalWidth += col.Width
			Next col

			totalWidth += dataGridView1.RowHeadersWidth

			Width = totalWidth + 60
		End Sub

		Protected Overrides Sub OnClosing(ByVal e As CancelEventArgs)
			'base.OnClosing(e);
			e.Cancel = True
			Hide()
		End Sub

	End Class
End Namespace