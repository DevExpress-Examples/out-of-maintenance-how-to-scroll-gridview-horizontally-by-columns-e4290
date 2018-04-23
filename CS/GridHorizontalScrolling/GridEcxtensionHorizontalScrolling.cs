using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Columns;

namespace GridHorizontalScrolling {
    public class GridEcxtensionHorizontalScrolling {
        GridView gridView;
        int FixedColumnsCount = 0;

        public GridEcxtensionHorizontalScrolling(GridView gridV) {
            gridView = gridV;
            gridView.ColumnChanged += gridView_ColumnChanged;
        }

        public void ScrollTo(int columnVisibleIndex) {
            int index = Math.Max(columnVisibleIndex, FixedColumnsCount);
            Scroll(index);
        }

        public void ScrollTo(GridColumn column) {
            int index = column.VisibleIndex;
            Scroll(index);
        }

        private void Scroll(int index) {
            int width = 0;
            for (int i = FixedColumnsCount; i < index; i++) {
                width += gridView.GetVisibleColumn(i).Width;
            }
            gridView.LeftCoord = width;
        }

        public void UpdateFixedColumnsCount() {
            FixedColumnsCount = 0;
            for (int i = 0; i < gridView.Columns.Count; i++)
                if (gridView.Columns[i].Fixed != FixedStyle.None)
                    FixedColumnsCount++;
        }

        public void ScrollForward() {
            int width = 0;
            for (int i = FixedColumnsCount; i < gridView.Columns.Count; i++) {
                width += gridView.GetVisibleColumn(i).Width;
                if (gridView.LeftCoord < width) {
                    gridView.LeftCoord = width;
                    break;
                }
                if (gridView.LeftCoord == width && i + 1 != gridView.Columns.Count) {
                    gridView.LeftCoord += gridView.GetVisibleColumn(i + 1).Width;
                    break;
                }
            }
        }

        public void ScrollBackward() {
            int width = 0;
            for (int i = FixedColumnsCount; i < gridView.Columns.Count; i++) {
                width += gridView.GetVisibleColumn(i).Width;
                if (gridView.LeftCoord < width) {
                    gridView.LeftCoord -= gridView.LeftCoord - (width - gridView.GetVisibleColumn(i).Width);
                    break;
                }
                if (gridView.LeftCoord == width) {
                    gridView.LeftCoord -= gridView.GetVisibleColumn(i).Width;
                    break;
                }
            }
        }


        public int UpdateIndexInEditor() {
            int index = FixedColumnsCount;
            int width = 0;
            if (gridView.LeftCoord != 0)
                for (int i = index; i < gridView.Columns.Count; i++) {
                    width += gridView.GetVisibleColumn(i).Width;
                    if (gridView.LeftCoord < width) {
                        index = i;
                        break;
                    }
                    if (gridView.LeftCoord == width) {
                        index = i + 1;
                        break;
                    }
                }
            return index;
        }

        void gridView_ColumnChanged(object sender, EventArgs e) {
            UpdateFixedColumnsCount();
        }
    }
}
