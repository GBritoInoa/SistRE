
function useAjax(url, data, onSuccess, method = "POST", async = true) {
    let configs = {
        type: method,
        url: url,
        async: async,
        data: data,
        contentType: "application/json; charset=utf-8",
        success: function (data, textStatus, jqXHR) {
            onSuccess(data);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            document.write(jqXHR.responseText);
        }
    };
    $.ajax(configs);
}
function fillDropDown(dropDwnSelector, data, valueMember, DisplayMember) {
    let optnsHtml = '';
    for (let optn of data) {
        optnsHtml += `<option value='${optn[valueMember]}'>${optn[DisplayMember]}</option>`;
    }
    $(dropDwnSelector).html(optnsHtml);
}

