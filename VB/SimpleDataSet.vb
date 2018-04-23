Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Data
Imports System.ComponentModel

Namespace ChartPivotInteractionApproaches
	Friend Class SimpleDataSet
		Inherits DataSet
		Public Sub New()
			Dim table As New DataTable("table")

			table.Columns.Add("ID", GetType(Int32))
			table.Columns.Add("row1", GetType(String))
			table.Columns.Add("row2", GetType(String))
			table.Columns.Add("row3", GetType(String))
			table.Columns.Add("data1", GetType(Double))
			table.Columns.Add("data2", GetType(Double))
			table.Columns.Add("data3", GetType(Double))
			table.Constraints.Add("IDPK", table.Columns("ID"), True)

			Tables.AddRange(New DataTable() { table })

			CreateData()
		End Sub

		Private Sub CreateData()
			Dim table As DataTable = Tables("table")

			table.Rows.Add(New Object() { 1, "VINET", "TOMSP", "HANAR", 25, 15, 9 })
			table.Rows.Add(New Object() { 2, "VINET", "TOMSP", "VICTE", 28, 51, 12 })
			table.Rows.Add(New Object() { 3, "VINET", "TOMSP", "SUPRD", 10, 158, 148 })

			table.Rows.Add(New Object() { 4, "VINET", "HANAR", "CHOPS", 52, 24, 83 })
			table.Rows.Add(New Object() { 5, "VINET", "HANAR", "RICSU", 45, 11, 51 })

			table.Rows.Add(New Object() { 6, "WELLI", "HILAA", "CENTC", 13, 32, 23 })
			table.Rows.Add(New Object() { 7, "WELLI", "HILAA", "OTTIK", 56, 67, 26 })
			table.Rows.Add(New Object() { 8, "WELLI", "HILAA", "QUEDE", 171, 120, 14 })

			table.Rows.Add(New Object() { 9, "WELLI", "ERNSH", "RATTC", 81, 62, 8 })
			table.Rows.Add(New Object() { 10, "WELLI", "ERNSH", "ERNSH", 35, 48, 64 })
		End Sub

		#Region "Disable Serialization for Tables and Relations"
		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Shadows ReadOnly Property Tables() As DataTableCollection
			Get
				Return MyBase.Tables
			End Get
		End Property

		<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
		Public Shadows ReadOnly Property Relations() As DataRelationCollection
			Get
				Return MyBase.Relations
			End Get
		End Property
		#End Region ' Disable Serialization for Tables and Relations

	End Class

End Namespace


