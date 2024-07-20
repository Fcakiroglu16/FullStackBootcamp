$(document).ready(function () {

    $("#btnCreate").click(function () {

        const payload = {

            userName: $("#Model_UserName").val(),
            email: $("#Model_Email").val(),
            password: $("#Model_Password").val(),


        }
        $.ajax({
            type: "POST",
            url: "http://localhost:5270/api/Identity/SignUp",
            contentType: "application/json",
            data: JSON.stringify(payload),
            success: function (response) {
                $("#errors").empty();

                $("#success").html(`     
                       <div class="alert alert-success">
                          Üye oluşturma işlemi başarıyla gerçekleşmiştir.
                          Üye giriş sayfasına yönlendiriliyorsunuz.
                       </div>`)


                setTimeout(function () {

                    location.href = "/Identity/SignIn";


                },2000)
            },
            error: function (fail) {


                console.log(fail.responseJSON.errors);
                // // jquery foreach
                $.each(fail.responseJSON.errors, function (index, value) {

                    $("#errors").append(`<p class="text-danger">${value}<p>`)
                })

            }
        })




    })




})