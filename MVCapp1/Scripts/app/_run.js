$(function () {
    app.initialize();

    // Aktywuj bibliotekę Knockout
    ko.validation.init({ grouping: { observable: false } });
    ko.applyBindings(app);
});
