function Delete(id, url) { 
    swal.fire({
        title: "Confirmation",
        text: "Are you sure you want to delete?",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!",
    }).then((result) => {
        if (result.isConfirmed) {
            $("#divLoader").show(); 
            axios.get(url, {
                params: { id: id },
                headers: {
                    'Content-Type': 'multipart/form-data',
                },
            }).then((res) => {
                    $("#divLoader").hide();
                    if (res && res.data && res.data.success) {
                        if (res.data.success) {
                            swal
                                .fire({
                                    icon: "success",
                                    title: "Success",
                                    text: res.data.message,
                                })
                                .then(function () {
                                    window.location.reload();
                                });
                        } else {
                            swal.fire({
                                icon: "warning",
                                title: "Failed",
                                text: res.data.message,
                            });
                        }
                    }
                })
                .catch((err) => {
                    swal.fire({
                        icon: "error",
                        title: "Failed",
                        text: "Error has occurred",
                    });
                });
        }
    });
}