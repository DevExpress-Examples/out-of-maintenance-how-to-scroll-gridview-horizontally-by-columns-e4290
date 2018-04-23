Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns

Namespace GridHorizontalScrolling
	Public Class GridEcxtensionHorizontalScrolling
		Private gridView As GridView
		Private FixedColumnsCount As Integer = 0

		Public Sub New(ByVal gridV As GridView)
			gridView = gridV
			AddHandler gridView.ColumnChanged, AddressOf gridView_ColumnChanged
		End Sub

		Public Sub ScrollTo(ByVal columnVisibleIndex As Integer)
			Dim index As Integer = Math.Max(columnVisibleIndex, FixedColumnsCount)
			Scroll(index)
		End Sub

		Public Sub ScrollTo(ByVal column As GridColumn)
			Dim index As Integer = column.VisibleIndex
			Scroll(index)
		End Sub

		Private Sub Scroll(ByVal index As Integer)
			Dim width As Integer = 0
			For i As Integer = FixedColumnsCount To index - 1
				width += gridView.GetVisibleColumn(i).Width
			Next i
			gridView.LeftCoord = width
		End Sub

		Public Sub UpdateFixedColumnsCount()
			FixedColumnsCount = 0
			For i As Integer = 0 To gridView.Columns.Count - 1
				If gridView.Columns(i).Fixed <> FixedStyle.None Then
					FixedColumnsCount += 1
				End If
			Next i
		End Sub

		Public Sub ScrollForward()
			Dim width As Integer = 0
			For i As Integer = FixedColumnsCount To gridView.Columns.Count - 1
				width += gridView.GetVisibleColumn(i).Width
				If gridView.LeftCoord < width Then
					gridView.LeftCoord = width
					Exit For
				End If
				If gridView.LeftCoord = width AndAlso i + 1 <> gridView.Columns.Count Then
					gridView.LeftCoord += gridView.GetVisibleColumn(i + 1).Width
					Exit For
				End If
			Next i
		End Sub

		Public Sub ScrollBackward()
			Dim width As Integer = 0
			For i As Integer = FixedColumnsCount To gridView.Columns.Count - 1
				width += gridView.GetVisibleColumn(i).Width
				If gridView.LeftCoord < width Then
					gridView.LeftCoord -= gridView.LeftCoord - (width - gridView.GetVisibleColumn(i).Width)
					Exit For
				End If
				If gridView.LeftCoord = width Then
					gridView.LeftCoord -= gridView.GetVisibleColumn(i).Width
					Exit For
				End If
			Next i
		End Sub


		Public Function UpdateIndexInEditor() As Integer
			Dim index As Integer = FixedColumnsCount
			Dim width As Integer = 0
			If gridView.LeftCoord <> 0 Then
				For i As Integer = index To gridView.Columns.Count - 1
					width += gridView.GetVisibleColumn(i).Width
					If gridView.LeftCoord < width Then
						index = i
						Exit For
					End If
					If gridView.LeftCoord = width Then
						index = i + 1
						Exit For
					End If
				Next i
			End If
			Return index
		End Function

		Private Sub gridView_ColumnChanged(ByVal sender As Object, ByVal e As EventArgs)
			UpdateFixedColumnsCount()
		End Sub
	End Class
End Namespace
