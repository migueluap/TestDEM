$(document).ready(function () {
    var txtUrlOriginal = $('#txtUrlOriginal');
    var btnSubmit = $('#btnSubmit');
    var divResponseArea = $('#divResponseArea');

    divResponseArea.hide();

    btnSubmit.click(function(){
        let urlInput = txtUrlOriginal.val();

        if (!isValidURL(urlInput)) {
            divResponseArea.show();
            return null;
        };

        $.ajax({
            url: "/urls/get-short/" + urlInput,
            type: 'post',
            content: "application/json; charset=utf-8",
            dataType: "json",
            crossDomain: true,
            success: function (data) {
                console.log(data);
                window.location.href = "/urls/" + data.shortCodeGenerated
            },
            error: function (errorMessage) {
                console.log(XMLHttpRequest);
                //console.log(textStatus);
                console.log(errorMessage);
            }
         });

        //window.location.href = "/urls/Sreate"
        //window.location.href = "/urls/GenerateUrlShort"
            
    });

});

function isValidURL(url) {
    let pattern = new RegExp('^(https?:\\/\\/)?' +
        '((([a-z\\d]([a-z\\d-]*[a-z\\d])*)\\.)+[a-z]{2,}|' +
        '((\\d{1,3}\\.){3}\\d{1,3}))' +
        '(\\:\\d+)?(\\/[-a-z\\d%_.~+]*)*' +
        '(\\?[;&a-z\\d%_.~+=-]*)?' +
        '(\\#[-a-z\\d_]*)?$', 'i');
    return pattern.test(url);
}

