const Hub = $.connection.notificationHub;
const DomOperations = {
    get filesTable() { return $('#filesTable'); },
    generateValidatingControl(tr) {
        let divEl = $(`<div class="position-relative loader-wrapper"></div>`);
        let el = tr.find('td.hidden').clone(true).show()
        let selectInp = el.find('select');
        let niceSelect = el.find('.nice-select ');
        let loadingEl = el.find('i');
        divEl.append(loadingEl).append(selectInp).append(niceSelect);
        return divEl;
    },
    generateValidatingDynamicsControl(tr) {
        let divEl = $(`<div class="position-relative loader-wrapper"></div>`);
        let el = tr.find('td.hidden').clone(true).show()
        let selectInp = el.find('a').show();
        let loadingEl = el.find('i');
        divEl.append(loadingEl).append(selectInp);
        return divEl;
    },
    changeGridFileStatus({ Item1:text,Item2:classname,Item3:status}) {
        if (!this.filesTable) return;
        let tr = this.filesTable.find('tbody tr').eq(0);
        let statusTd = tr.find('td.status');
        let controlTd = tr.find('td.control');
        statusTd.empty().append(`<span class="${classname}">${text}</span>`);
        if (status == 1) {
            //validating 
            let _controlEl = this.generateValidatingControl(tr);
            controlTd.empty().append(_controlEl);
        }
        else if (status == 2) {
            //done
            controlTd.empty();
        }
        else if (status == 3) {
            //cancelled
            controlTd.empty();
        }
        else if (status == 4) {
            //importing to crm
            controlTd.empty();
        }
        else if (status == 5) {
            let _controlEl = this.generateValidatingDynamicsControl(tr);
            controlTd.empty().append(_controlEl);
            //Validate Renewable Dynamic 
        }
    }
}
const hubOperations = {
    userId: window.userId,
    configProgressbar() {
        $(document).ready(function () {
            $('#ProgressBar').progressbar({
                value: 0,
                max: 100,
                min: 0
            });

        });
    },
    configureHub() {
        $.connection.hub.logging = true;
        $.connection.hub.qs = "UserId=" + this.userId;
        $.connection.hub.start();
        Hub.client.alert = this.onAlert;
        Hub.client.ProgressBar = this.onProgressBarChanges;
        Hub.client.changeFileStatus = this.onFileStatusChange;
    },
    onAlert(mess) {
        viewToaster(mess)
    },
    onProgressBarChanges(val) {
        ChangeProgressBar(val)
    },
    onFileStatusChange(status) {
        DomOperations.changeGridFileStatus(status);
    },
    init() {
        this.configProgressbar();
        this.configureHub();
    }
}

hubOperations.init();

function sendMessage(status) {
    $.get('/home/signal?user=' + hubOperations.userId+'&status='+status)
        .then((m) => {
            console.log(m)
        })
        .fail(err => {
            console.log(err)
        })
}