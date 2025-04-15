window.initAdminLTE = () => {
    // AdminLTE usually auto-inits, but this can help
    $('[data-toggle="dropdown"]').dropdown();
    // Re-initialize tooltips, etc.
    $('[data-toggle="tooltip"]').tooltip();
};
