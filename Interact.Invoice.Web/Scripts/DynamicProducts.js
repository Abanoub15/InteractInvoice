
const domElements = {
    get sumbmitBtn() {
        return $('#submitBtn')
    },
    get submitBtnSpinner() {
        return $('#submitBtnSpinner')
    },
    get mainTable() {
        return $('#productsTable')
    },
    get tableOverlay() {
        return $('#tableOverlay');
    },
    get alertDivError() {
        return $('#alert-error')
    },
    toogleBtnLoading() {
        //this.mainTable.toggleClass('active');
        this.sumbmitBtn.toggleClass('disabled');
        this.submitBtnSpinner.toggleClass('d-none');
    },
    toogleBtnLoadingWithNoOverlay() {
        this.sumbmitBtn.toggleClass('disabled');
        this.submitBtnSpinner.toggleClass('d-none');
    },
    toggleOverlay() {
        this.mainTable.toggleClass('active');
        this.tableOverlay.toggleClass('d-none');
    },
    toggleError() {
        this.alertDivError.toggleClass('d-none');
    },
    triggerTableClick() {
        $('#productsTable .wtHider').on('click', () => {
            this.alertDivError.addClass('d-none');
        });
    }
}

const tbHelber= {
    get getTaleData() {
        return dynamicTbHot.getData();
    },
    getCellValue(row, col) {
        if (row < 0) return null;
        return this.getTaleData[row][col];
    },
    resetCellValue(row,col,value=null,source=null) {
       dynamicTbHot.selectCell(row, col);
       dynamicTbHot.setDataAtCell(row, col, value, source);
    },
    setCellDisabled(_row, _col) {
        let isUpdated = false;
       dynamicTbHot.updateSettings({
            cells: function (row, col) {
                var cellProperties = this;
                if (col == _col && row ==_row && !isUpdated) {
                    cellProperties.editor = false;
                    isUpdated = true;
                }
                return cellProperties;
            }
        });
    },
    setCellEnabled(_row, _col, _editorType, _cellType, _source,_select){
    let isUpdated = false;
   dynamicTbHot.updateSettings({
        cells: function (row, col) {
            var cellProperties = this;

            if (col == _col && row == _row && !isUpdated) {
                if (_editorType) cellProperties.editor = _editorType;
                if (_cellType) cellProperties.type = _cellType;
                if (_source) cellProperties.source = _source;
                if (_select) cellProperties.selectOptions = _select;
                isUpdated = true;
            }
            return cellProperties;
        }
      });
    },
    get props() {
        return ["Part Number", "Renewable Du",""];
    },   
    handleGlobalAjaxOperation() {
        $.ajaxSettings.beforeSend = () => {
            domElements.toggleOverlay();
        };
        $.ajaxSettings.error = () => {
            domElements.toggleOverlay();
        };
        $.ajaxSettings.complete = () => {
            domElements.toggleOverlay();
        }
    },
    startListenToTableChanges() {
        const $this = this;
       dynamicTbHot.addHook('afterChange', function (changes,source) {
            if (!changes) return;
            changes.forEach((props) => {
                $this.onTableChanges(props);
            });
        });
    },
    init() {
        this.handleGlobalAjaxOperation();
        //this.startListenToTableChanges();
    }
}

const tableConfig = {
    startRows: 0,
    startCols: 0,
    data: objectData,
    stretchH: 'all',
    contextMenu: true,
    colHeaders:tbHelber.props ,
    rowHeights: 40,
    setValueAtCell(col,row,val) {
        var cell =dynamicTbHot.getCell(1, 8);
        let $cell = $(cell);
    },
    columnHeaderHeight: 40,
    rowHeaders: true,
    //colHeaders: true,
    hiddenColumns: {
        columns: [2],
        indicators: false
    },
    columns: [
        {
            data: "PartNumber",
            readOnly: true
        },
        {
            type: 'numeric',
            strict: true
        },
        {
            data: "FileId"
        }
    ],
    filters: true,
    dropdownMenu: true,
    columnSorting: true,
    beforeKeyDown: function (e) {
        var selectedLast = this.getSelectedLast();
        if (!selectedLast) {
            return;
        }
        var row = selectedLast[0];
        var col = selectedLast[1];
        var celltype = this.getCellMeta(row, col).type;

        // prevent Alpha chars in numeric sheet cells
        if (celltype === "numeric") {
            var evt = e || window.event; // IE support
            var key = evt.charCode || evt.keyCode || 0;


            // check for cut and paste
            var isClipboard = false;
            var ctrlDown = evt.ctrlKey || evt.metaKey; // Mac support

            // Check for Alt+Gr (http://en.wikipedia.org/wiki/AltGr_key)
            if (ctrlDown && evt.altKey) isClipboard = false;
            // Check for ctrl+c, v and x
            else if (ctrlDown && key == 67) isClipboard = true; // c
            else if (ctrlDown && key == 86) isClipboard = true; // v
            else if (ctrlDown && key == 88) isClipboard = true; // x

            // allow backspace, tab, delete, enter, arrows, numbers and keypad numbers
            // ONLY home, end, F5, F12, minus (-), period (.)
            // console.log('Key: ' + key + ' Shift: ' + e.shiftKey + ' Clipboard: ' + isClipboard);
            var isNumeric = ((key == 8) || (key == 9) || (key == 13) || (key == 46)
                || (key == 116) || (key == 123) 
                || ((key >= 35) && (key <= 40)) || ((key >= 48) && (key <= 57))
                || ((key >= 96) && (key <= 105)));

            //check if cell is allowable to write
            let isRenewable = tbHelber.getCellValue(row, col - 1);
            let isBackspace= (key == 8);

            if ((!isNumeric && !isClipboard) || e.shiftKey || (!isRenewable && !isBackspace)) {
                // prevent alpha characters
                e.stopImmediatePropagation();
                e.preventDefault();
            }

             
        }
    } 
};

const dynamicTbHot = new Handsontable(document.getElementById('productsTable'), tableConfig);

$(document).ready(function () {
    tbHelber.init();
    domElements.triggerTableClick();
});

const submitter = {
    _validatedData: [],
    submitDataToSrm() {       
        let valResult = this.validateTbdata();
        if (!valResult.status) {
            if (valResult.reason == 'empty') {
                toastr.error('please fill the empty cells first ,then click submit');
            }
            return;
        }
        domElements.toogleBtnLoading();
        let data =tbHelber.getTaleData;

        $.ajax({
            url: '/SubmitProducts/PostDynamicsProducts',
            type: "POST",
            dataType: 'json',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (result) {
                toastr.success('Data Submitted Successfully, you\'ll be redirect to the home page');
                setTimeout(() => {
                    location.href = `/`;
                }, 3000);
            },
            complete: () => {
                domElements.toogleBtnLoading();
            },
            error: () => {
                domElements.toggleOverlay();
                toastr.error("the operation doesn't complete cause of server error")
            }
        });
    },
    validateTbdata() {
        let _data = tbHelber.getTaleData;
        let rows = _data.length; 
        for (let i = 0; i < rows; i++) {
            let row = _data[i];
            let hasValue = !row.some(f => !(f || (f && f.trim())));
            if (!hasValue)
            return {
                status: false,
                reason: 'empty'
            };
        }
        return {status:true}
    },
   
    _makeCellAsError(col, row) {
        domElements.toggleError();
        var cell =dynamicTbHot.getCell(row, col);
        let $cell = $(cell);
        $cell.addClass('cell-error');
        $cell.one('click', function () {
            $cell.removeClass('cell-error');
        });
    }
}
