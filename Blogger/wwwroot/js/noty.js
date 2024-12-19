

document.addEventListener('DOMContentLoaded', function () {
    var type = '@TempData["NotificationType"]';
    var message = '@TempData["NotificationMessage"]';

    if (type && message) {
        new Noty({
            type: type.trim(), 
            text: message.trim(),
            timeout: 3000,
            progressBar: true,
            layout: 'topLeft'
        }).show();
    }
});