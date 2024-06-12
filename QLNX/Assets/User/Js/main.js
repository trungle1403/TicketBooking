
$(document).ready(function () {
    $('.selectpicker').attr('data-live-search', true);

    });

// hàm format số
function formatNumber(num) {
    return num.toString().replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,') + ' VND';
}
//login
$(document).ready(function () {
   // $(".email-signup").hide();
    $("#signup-box-link").click(function () {
        $(".email-login").fadeOut(100);
        $(".email-signup").delay(100).fadeIn(100);
        $("#login-box-link").removeClass("active");
        $("#signup-box-link").addClass("active");
    });
    $("#login-box-link").click(function () {
        $(".email-login").delay(100).fadeIn(100);;
        $(".email-signup").fadeOut(100);
        $("#login-box-link").addClass("active");
        $("#signup-box-link").removeClass("active");
    });
})

$(document).ready(function () {
    $("#btnLogin").click(function (evt) {
        // để trống các trường trang login
        if (document.getElementById("SDTDN").value.length == 0 || document.getElementById("MKDN").value.length == 0) {
            // chặn submit của form
            evt.preventDefault();
            Swal.fire({
                icon: 'warning',
                title: 'Thông báo',
                text: 'Hãy nhập đủ thông tin!',
                // toast:'false',
                confirmButtonText: 'OK',
                timer: 2500
            })
        } else if (document.getElementById("SDTDN").value.length != 10) {
            evt.preventDefault();
            Swal.fire({
                icon: 'warning',
                title: 'Thông báo',
                text: 'Số điện thoại phải đủ 10 số!',
                // toast:'false',
                confirmButtonText: 'OK',
                timer: 2500
            })
        } else if (isNaN(document.getElementById("SDTDN").value) == true) {
            evt.preventDefault();
            Swal.fire({
                icon: 'warning',
                title: 'Thông báo',
                text: 'Số điện thoại phải là kiểu số',
                // toast:'false',
                confirmButtonText: 'OK',
                timer: 2500
            })
        }
    })
    $("#btnSignin").click(function (evt) {
        //để trống trang signin
        if (document.getElementById("SDTDK").value.length == 0 || document.getElementById("MKDK").value.length == 0 ||
            document.getElementById("MAIL").value.length == 0 || document.getElementById("MKXN").value.length == 0 || document.getElementById("HOTEN").value.length == 0) {
            // chặn submit của form
            evt.preventDefault();
            Swal.fire({
                icon: 'warning',
                title: 'Thông báo',
                text: 'Hãy nhập đủ thông tin!',
                confirmButtonText: 'OK',
                timer: 2500
            })
        }
        else if (document.getElementById("SDTDK").value.length != 10) {
            evt.preventDefault();
            Swal.fire({
                icon: 'warning',
                title: 'Thông báo',
                text: 'Số điện thoại phải đủ 10 số!',
                confirmButtonText: 'OK',
                timer: 2500
            })
        } else if (isNaN(document.getElementById("SDTDK").value) == true) {
            evt.preventDefault();
            Swal.fire({
                icon: 'warning',
                title: 'Thông báo',
                text: 'Số điện thoại phải là kiểu số',
                confirmButtonText: 'OK',
                timer: 2500
            })
        }
        else if (document.getElementById("MKDK").value != document.getElementById("MKXN").value) {
            evt.preventDefault();
            Swal.fire({
                icon: 'warning',
                title: 'Thông báo',
                text: 'Mật khẩu xác nhận không đúng',
                confirmButtonText: 'OK',
                timer: 2500
            })
        }
    })
})

$(document).ready(function (evt) {
    $("#btnCheckout").click(function (evt){
        if (document.getElementById("PTTHANHTOAN").value.length == 0) {
            evt.preventDefault();
            Swal.fire({
                icon: 'warning',
                title: 'Thông báo',
                text: 'Chưa chọn phương thức thanh toán!',
                // toast:'false',
                confirmButtonText: 'OK',
                timer: 2500
            })
        } else if (document.getElementById("HOTEN").value.length == 0) {
            evt.preventDefault();
            Swal.fire({
                icon: 'warning',
                title: 'Thông báo',
                text: 'Họ tên không được bỏ trống!',
                // toast:'false',
                confirmButtonText: 'OK',
                timer: 2500
            })
        }
        else if (document.getElementById("SDT").value.length == 0) {
            evt.preventDefault();
            Swal.fire({
                icon: 'warning',
                title: 'Thông báo',
                text: 'Số điện thoại không được bỏ trống!',
                // toast:'false',
                confirmButtonText: 'OK',
                timer: 2500
            })
        }
        else if (document.getElementById("EMAIL").value.length == 0) {
            evt.preventDefault();
            Swal.fire({
                icon: 'warning',
                title: 'Thông báo',
                text: 'Email không được bỏ trống!',
                // toast:'false',
                confirmButtonText: 'OK',
                timer: 2500
            })
        }
        else if (document.getElementById("SDT").value.length != 10) {
            evt.preventDefault();
            Swal.fire({
                icon: 'warning',
                title: 'Thông báo',
                text: 'Số điện thoại phải đủ 10 số!',
                // toast:'false',
                confirmButtonText: 'OK',
                timer: 2500
            })
        }
    }) //end click


    $('#btnDropdown').click(function (evt) {
        $('#ul').toggleClass('active');
    })

    $("#btnTim").click(function (evt) {
        if ($("#DIADIEMDI").val() == "") {
            evt.preventDefault();
            
            const Toast = Swal.mixin({
                toast: true,
                position: 'center-end',
                showConfirmButton: false,
                timer: 3000,
            })

            Toast.fire({
                icon: 'error',
                title: 'Chưa chọn điểm đi!!!'
            })
        }  else if ($("#DIADIEMDEN").val() == "") {
            evt.preventDefault();

            const Toast = Swal.mixin({
                toast: true,
                position: 'center-end',
                showConfirmButton: false,
                timer: 3000,
            })

            Toast.fire({
                icon: 'error',
                title: 'Chưa chọn điểm đến!!!'
            })
        } else if ($(".ngay").val() == "") {
            evt.preventDefault();

            const Toast = Swal.mixin({
                toast: true,
                position: 'center-end',
                showConfirmButton: false,
                timer: 3000,
            })

            Toast.fire({
                icon: 'error',
                title: 'Chưa chọn ngày khởi hành!!!'
            })
        } //end if
    }) //end click
    $("#ttcn").click(function (evt) {
        const Toast = Swal.mixin({
            toast: true,
            position: 'top-end',
            showConfirmButton: false,
            timer: 3000,
        })

        Toast.fire({
            icon: 'warning',
            title: 'Chức năng đang phát triển'
        })
    })
    function dangerAlertSmall(s) {
        const Toast = Swal.mixin({
            toast: true,
            position: 'top-end',
            showConfirmButton: false,
            timer: 3000,
        })

        Toast.fire({
            icon: 'error',
            title: s
        })
    }
       
    

})//end document

