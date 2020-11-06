// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Ajax helper functions
function ajax(settings) {
    var processing = false;

    if (!settings.url) throw 'No url was specified';

    var url = settings.url; //resolveUrl(settings.url);
    var cache = settings.cache || false;
    var dataType = settings.dataType || 'json';
    var contentType = settings.contentType || 'application/x-www-form-urlencoded; charset=UTF-8'; //application/json; charset=utf-8';
    var type = settings.type || 'GET';
    var success = settings.success;
    var error = settings.error || ((jqXHR, textStatus, errorThrown) => { debugger; });

    var beforeSend = settings.beforeSend ||
        function () {
            processing = true;

            setTimeout(function () {
                if (processing)
                    $('body').addClass('loading');
            }, 400);
        };

    var complete = settings.complete ||
        function () {
            processing = false;
            $('body').removeClass('loading');
        };

    if (settings.data)
        //debugger;
        return $.ajax({
            url: url,
            cache: cache,
            dataType: dataType,
            contentType: contentType,
            data: settings.data,
            type: type,
            beforeSend: beforeSend,
            success: success,
            error: error,
            complete: complete
        });
    else
        return $.ajax({
            url: url,
            cache: cache,
            dataType: dataType,
            type: type,
            beforeSend: beforeSend,
            success: success,
            error: error,
            complete: complete
        });
}

// required: url, data, target (you may pass in a css selector or jQuery object for target)
// optional: type (defaults to POST), success 
function showPartialView(parameters) {
    ajax({
        url: parameters.url,
        dataType: 'html',
        data: parameters.data,
        type: parameters.type || 'POST',
        success: function (data) {
            let target = (parameters.target instanceof jQuery) ?
                parameters.target : $(target);

            target.html(data);

            if (parameters.success)
                parameters.success();
        }
    });
}