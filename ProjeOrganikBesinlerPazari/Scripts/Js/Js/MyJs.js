//var LblUrun1 = document.getElementById('LblUrun1');
//var LblUrun2 = document.getElementById('LblUrun2');
//var LblUrun3 = document.getElementById('LblUrun3');
//var LblUrun4 = document.getElementById('LblUrun4');


//function UrunGoster() {



//    $.ajax({
//        url: "/Home/Indexa",
//        success: function (result, e, f) {
//            if (f.status === 200) {
//                var LblUrun1 =  document.getElementById('LblUrun1');
//                LblUrun1.innerText = result.UrunAdi;
//            }
           
//        },
//        method: "GET"
//    }).done(function (result, e, f) {
//        var f = result;
//    }).fail(function (result, e, f) {
        
//    }).catch(function (result, e, f) {
//        var h = result;
//    }).progress(function (result, e, f) {
//        var y = result;
//    });


//}





//function UrunGetir() {

//    $.ajax({
//        url: "/Home/Indexa",
//        success: function (result, e, f) {
//            if (f.status === 200) {
//                var LblUrun1 =  document.getElementById('LblUrun1');
//                LblUrun1.innerText = result.UrunAdi;
//            }
           
//        },
//        method: "GET"
//    }).done(function (result, e, f) {
//        var f = result;
//    }).fail(function (result, e, f) {
        
//    }).catch(function (result, e, f) {
//        var h = result;
//    }).progress(function (result, e, f) {
//        var y = result;
//    });

//}





function UrunListele() {
    $("#BtnUrunListele").click(function () {
        var Id = $("#UrunId").val();
        $.ajax({

            url: '/Home/UrunListele/' + Id,
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                $("#TxtUrunAdi").html(data.UrunAdi);
                $("#TxtUrunFiyati").html(data.UrunFiyati);

            },
            error: function (data) {
                alert("Bu ıd'ye ait veri yok");
            }

        });

    });

}



function TumUrunListele() {
    $("#BtnTumUrunListele").click(function () {
       
        $.ajax({

            url: '/Home/UrunListele/',
            type: 'GET',
            dataType: 'json',
            success: function (data)
            {
                $.each(data, function(i,item) {
                    $("#TumUrunler").append(
                        "<div> <ul>" + "<li>Ürün Adı: "
                        + item.UrunAdi + "     " + "Ürün Fiyatı: " + item.UrunFiyati + "</li>" +
                    "<br/></ul></div>" 
                    );

                })

            },
            error: function (data) {
                alert("Buraya ait veri yok");
            }

        });

    });

}