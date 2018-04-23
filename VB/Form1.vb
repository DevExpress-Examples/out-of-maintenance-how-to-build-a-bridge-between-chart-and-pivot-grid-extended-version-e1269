Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Collections
Imports DevExpress.XtraCharts
Imports DevExpress.XtraPivotGrid
Imports System.Reflection
Imports DevExpress.XtraPivotGrid.ViewInfo

Namespace ChartPivotInteractionApproaches
	Partial Public Class Form1
		Inherits Form
		Private intermidiateTable As DataTable
		Private currentChartDataSourceType As ChartDataSourceType
		Private actualDataTableForm As Form2

		Public Sub New()
			InitializeComponent()

			intermidiateTable = New DataTable()
			currentChartDataSourceType = ChartDataSourceType.PivotGrid
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			pivotGridControl1.CollapseAll()
			chartControl1.Series.Clear()
			InitializeMenuItemsState()

			TransferData(currentChartDataSourceType)

			actualDataTableForm = New Form2()

			actualDataTableForm.BrowsableTable = intermidiateTable
			actualDataTableForm.Owner = Me
			actualDataTableForm.Show()

			Me.Location = New Point(0, 0)
			actualDataTableForm.Location = New Point(Me.Width, 0)
		End Sub

		Private Sub InitializeMenuItemsState()
			chartDataVerticalToolStripMenuItem.Checked = pivotGridControl1.OptionsChartDataSource.ChartDataVertical
			selectionOnlyToolStripMenuItem.Checked = pivotGridControl1.OptionsChartDataSource.SelectionOnly

			If currentChartDataSourceType = ChartDataSourceType.PivotGrid Then
				pivotGridToolStripMenuItem.Checked = True
				pivotSummaryToolStripMenuItem.Checked = False
				chartDataVerticalToolStripMenuItem.Enabled = True
				selectionOnlyToolStripMenuItem.Enabled = True
			ElseIf currentChartDataSourceType = ChartDataSourceType.PivotSummary Then
				pivotGridToolStripMenuItem.Checked = False
				pivotSummaryToolStripMenuItem.Checked = True
				chartDataVerticalToolStripMenuItem.Enabled = False
				selectionOnlyToolStripMenuItem.Enabled = False
			End If
		End Sub

		Private Sub pivotGridControl1_CellSelectionChanged(ByVal sender As Object, ByVal e As EventArgs) Handles pivotGridControl1.CellSelectionChanged
			TransferData(currentChartDataSourceType)
		End Sub

		Private Sub pivotGridControl1_CellClick(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PivotCellEventArgs) Handles pivotGridControl1.CellClick
			TransferData(currentChartDataSourceType)
		End Sub

		Private Sub pivotGridControl1_FieldValueExpanded(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PivotFieldValueEventArgs) Handles pivotGridControl1.FieldValueExpanded
			TransferData(currentChartDataSourceType)
		End Sub

		Private Sub pivotGridControl1_FieldValueCollapsed(ByVal sender As Object, ByVal e As DevExpress.XtraPivotGrid.PivotFieldValueEventArgs) Handles pivotGridControl1.FieldValueCollapsed
			TransferData(currentChartDataSourceType)
		End Sub

		Private Sub cbArgVal_SelectedValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbArgument.SelectedValueChanged, cbValue.SelectedValueChanged
			BindChartToIntermidiateTable(currentChartDataSourceType)
		End Sub

		#Region "CoreFunctionality"
		Public Sub TransferData(ByVal chartDataSourceType As ChartDataSourceType)
			CreateIntermidiateTableSchema(chartDataSourceType)
			FillArgValComboBoxes()
			FillIntermidiateTable(chartDataSourceType)
			BindChartToIntermidiateTable(chartDataSourceType)
		End Sub

		Private Sub CreateIntermidiateTableSchema(ByVal chartDataSourceType As ChartDataSourceType)
			Dim columnsInfo As PropertyDescriptorCollection = Nothing

			If chartDataSourceType = ChartDataSourceType.PivotGrid Then
				columnsInfo = (CType(pivotGridControl1, ITypedList)).GetItemProperties(Nothing)
			ElseIf chartDataSourceType = ChartDataSourceType.PivotSummary Then
				columnsInfo = (CType(pivotGridControl1.CreateSummaryDataSource(), ITypedList)).GetItemProperties(Nothing)
			End If

			intermidiateTable.Columns.Clear()
			For Each propertyDescriptor As PropertyDescriptor In columnsInfo
				intermidiateTable.Columns.Add(propertyDescriptor.Name, propertyDescriptor.PropertyType)
			Next propertyDescriptor
		End Sub

		Private Sub FillIntermidiateTable(ByVal chartDataSourceType As ChartDataSourceType)
			Dim realDataSource As Object = Nothing

			If chartDataSourceType = ChartDataSourceType.PivotGrid Then
				realDataSource = pivotGridControl1
			ElseIf chartDataSourceType = ChartDataSourceType.PivotSummary Then
				realDataSource = pivotGridControl1.CreateSummaryDataSource()
			End If

			intermidiateTable.Rows.Clear()
			For i As Integer = 0 To (CType(pivotGridControl1, IList)).Count - 1
				Dim row As DataRow = intermidiateTable.NewRow()

				For Each d As PropertyDescriptor In (CType(realDataSource, ITypedList)).GetItemProperties(Nothing)
					Dim value As Object = d.GetValue((CType(realDataSource, IList))(i))
					If value IsNot Nothing Then
						row(d.Name) = (value)
					Else
						row(d.Name) = (DBNull.Value)
					End If
				Next d

				intermidiateTable.Rows.Add(row)
			Next i
		End Sub

		Private Sub BindChartToIntermidiateTable(ByVal chartDataSourceType As ChartDataSourceType)
			chartControl1.DataSource = intermidiateTable

			If chartDataSourceType = ChartDataSourceType.PivotGrid Then
				chartControl1.SeriesDataMember = "Series"
				chartControl1.SeriesTemplate.ArgumentDataMember = "Arguments"
				chartControl1.SeriesTemplate.ValueDataMembers.AddRange(New String() { "Values" })
			ElseIf chartDataSourceType = ChartDataSourceType.PivotSummary Then
				If cbArgument.Text IsNot Nothing AndAlso cbValue.Text IsNot Nothing Then
					Try
						chartControl1.Series.Clear()
						chartControl1.Series.Add(New Series("Series", ViewType.Bar))
						chartControl1.Series(0).ArgumentDataMember = cbArgument.Text
						chartControl1.Series(0).ValueDataMembers.AddRange(New String() { cbValue.Text })
					Catch ex As Exception
						MessageBox.Show(ex.Message)
					End Try
				End If
			End If

			chartControl1.RefreshData()
		End Sub

		Private Sub FillArgValComboBoxes()
			cbArgument.Items.Clear()
			cbValue.Items.Clear()
			For i As Integer = 0 To intermidiateTable.Columns.Count - 1
				cbArgument.Items.Add(intermidiateTable.Columns(i).ColumnName)
				cbValue.Items.Add(intermidiateTable.Columns(i).ColumnName)
			Next i
		End Sub
		#End Region ' CoreFunctionality

		#Region "DrillDownFeature"
		Private Sub chartControl1_ObjectHotTracked(ByVal sender As Object, ByVal e As HotTrackEventArgs) Handles chartControl1.ObjectHotTracked
			If e.HitInfo.SeriesPoint IsNot Nothing Then
				Cursor = System.Windows.Forms.Cursors.Hand
			Else
				Cursor = System.Windows.Forms.Cursors.Default
			End If
		End Sub

		Private Sub chartControl1_ObjectSelected(ByVal sender As Object, ByVal e As HotTrackEventArgs) Handles chartControl1.ObjectSelected
			Dim seriesPoint As SeriesPoint = e.HitInfo.SeriesPoint

			If seriesPoint IsNot Nothing Then
				Dim values() As String = seriesPoint.Argument.ToString().Split(New String() { " | " }, StringSplitOptions.None)
				Dim fields As List(Of PivotGridField) = New List(Of PivotGridField)()

				pivotGridControl1.CollapseAll()
				'return;
				For Each pivotGridField As PivotGridField In pivotGridControl1.Fields
					If pivotGridField.Area = PivotArea.RowArea OrElse pivotGridField.Area = PivotArea.ColumnArea Then
						fields.Add(pivotGridField)
					End If
				Next pivotGridField

				' Expand field values
				For i As Integer = 0 To values.Length - 1
					Dim fieldToExpand As PivotGridField = GetFieldByAreaIndex(fields, i)

					If fieldToExpand Is Nothing Then
						Continue For
					End If

					If Microsoft.VisualBasic.Information.IsNumeric(values(i)) Then
						If fieldToExpand.DataType Is GetType(Int32) Then
							fieldToExpand.ExpandValue(Int32.Parse(values(i)))
						ElseIf fieldToExpand.DataType Is GetType(Double) Then
							fieldToExpand.ExpandValue(Double.Parse(values(i)))
						End If
					ElseIf Microsoft.VisualBasic.Information.IsDate(values(i)) Then
						fieldToExpand.ExpandValue(DateTime.Parse(values(i)))
					Else
						fieldToExpand.ExpandValue(values(i).ToString())
					End If
				Next i
				'return;
				' Make cells selection
				Dim selectedCells As List(Of Point) = New List(Of Point)()
				Dim lastIndex As Integer = values.Length - 1

				System.Threading.Thread.Sleep(100)
				For i As Integer = 0 To pivotGridControl1.Cells.RowCount - 1
					Dim skipFlag As Boolean = False
					For j As Integer = 0 To values.Length - 1
						Dim value As Object = pivotGridControl1.GetFieldValue(GetFieldByAreaIndex(fields, j), i)

						If (Not Object.Equals(value, values(j))) Then
							skipFlag = True
						End If
					Next j

					If skipFlag Then
						Continue For
					End If

					For j As Integer = 0 To pivotGridControl1.Cells.ColumnCount - 1
						selectedCells.Add(New Point(j, i))
					Next j
				Next i

				If selectedCells.Count <> 0 Then
					pivotGridControl1.Cells.FocusedCell = selectedCells(0)
					pivotGridControl1.Cells.MultiSelection.SetSelection(selectedCells.ToArray())
				End If
			End If
		End Sub

		Private Function GetFieldByAreaIndex(ByVal fields As List(Of PivotGridField), ByVal areaIndex As Integer) As PivotGridField
			For Each f As PivotGridField In fields
				If f.AreaIndex = areaIndex Then
					Return f
				End If
			Next f

			Return Nothing
		End Function
		#End Region ' DrillDownFeature

		#Region "MenuItemsHandling"
		Private Sub actualDataTableToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles actualDataTableToolStripMenuItem.Click
			actualDataTableForm.Show()
		End Sub

		Private Sub selectionOnlyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles selectionOnlyToolStripMenuItem.Click
			pivotGridControl1.OptionsChartDataSource.SelectionOnly = Not pivotGridControl1.OptionsChartDataSource.SelectionOnly
			TransferData(currentChartDataSourceType)
		End Sub

		Private Sub chartDataVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles chartDataVerticalToolStripMenuItem.Click
			pivotGridControl1.OptionsChartDataSource.ChartDataVertical = Not pivotGridControl1.OptionsChartDataSource.ChartDataVertical
			TransferData(currentChartDataSourceType)
		End Sub

		Private Sub pivotGridToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles pivotGridToolStripMenuItem.Click
			pivotGridToolStripMenuItem.Checked = True
			pivotSummaryToolStripMenuItem.Checked = False
			chartDataVerticalToolStripMenuItem.Enabled = True
			selectionOnlyToolStripMenuItem.Enabled = True
			cbArgument.Enabled = False
			cbValue.Enabled = False
			currentChartDataSourceType = ChartDataSourceType.PivotGrid
			TransferData(currentChartDataSourceType)
		End Sub

		Private Sub pivotSummaryToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles pivotSummaryToolStripMenuItem.Click
			pivotSummaryToolStripMenuItem.Checked = True
			pivotGridToolStripMenuItem.Checked = False
			chartDataVerticalToolStripMenuItem.Enabled = False
			selectionOnlyToolStripMenuItem.Enabled = False
			cbArgument.Enabled = True
			cbValue.Enabled = True
			currentChartDataSourceType = ChartDataSourceType.PivotSummary
			TransferData(currentChartDataSourceType)
		End Sub

		Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitToolStripMenuItem.Click
			Application.Exit()
		End Sub
		#End Region ' MenuItemsHandling
	End Class

	Public Enum ChartDataSourceType
		PivotGrid = 0
		PivotSummary = 1
	End Enum

End Namespace