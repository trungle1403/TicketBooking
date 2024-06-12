const inputs = document.querySelectorAll(".input");


function addcl(){
	let parent = this.parentNode.parentNode;
	parent.classList.add("focus");
}

function remcl(){
	let parent = this.parentNode.parentNode;
	if(this.value == ""){
		parent.classList.remove("focus");
	}
}


inputs.forEach(input => {
	input.addEventListener("focus", addcl);
	input.addEventListener("blur", remcl);
});



const menubtn = document.querySelector('.menuBtn');
let menuOpen = false;
menubtn.addEventListener('click', () => {
    if (!menuOpen){
        menubtn.classList.add('openmenu');

        menuOpen = true;
    } else 
    {
        menubtn.classList.remove('openmenu');
        menuOpen = false;
    }
    
});
let n = 1;
menubtn.addEventListener('click', () => {
    if(n%2 != 0)
    {
        document.querySelector('.menuBar').style.left = 0;
        n++;
    }
    else
    {
        document.querySelector('.menuBar').style.left = '-100%';
        n++;
    }

});
$(document).ready(function () {
    $('#dataTable').DataTable({
        "language": {
            "sProcessing": "Đang xử lý...",
            "sLengthMenu": "Xem _MENU_ mục",
            "sZeroRecords": "Không tìm thấy dòng phù hợp",
            "sInfo": "Đang xem _START_ đến _END_ trong tổng số _TOTAL_ mục",
            "sInfoEmpty": "Đang xem 0 đến 0 trong tổng số mục",
            "sInfoFiltered": "(được lọc từ _MAX_ mục)",
            "sInfoPostFix": "",
            "sSearch": "Tìm:",
            "sUrl": "",
            "oPaginate": {
                "sFirst": "Đầu",
                "sPrevious": "Trước",
                "sNext": "Tiếp",
                "sLast": "Cuối"
            }
        }
    })

    
})


// show alert
function showAlertSmall(s) {
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

function showAlertSuccess(s) {
    Swal.fire({
        icon: 'success',
        title: 'Thông báo',
        text: s,
        confirmButtonText: 'OK',
        timer: 2000
    })
}


$(document).ready(function () {
    $("#dpd1").datepicker();
})

