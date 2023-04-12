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




//verilen ıdye göre listeliyor
function UrunListele() {
    $("#BtnUrunListele").click(function () {
        var Id = $("#UrunId").val();
        var Resim = document.getElementById("TxtResim");
        
        $.ajax({

            url: '/Home/UrunListele/' + Id,
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                $("#TxtUrunAdi").html(data.UrunAdi);
                $("#TxtUrunFiyati").html(data.UrunFiyati);
                //var srce = "~/web/images/bg2.jpg";
                //$("Resim").html("~/web/images/bg2.jpg");

               /* $("#TxtResim").attr(src, "~/web/images/bg2.jpg");*/

               /* $("#TxtUrunKategori").html(data.StokAdedi);*/
                //var resim = "~/Upload/sebze.jpg";
                //$('#TxtResim').attr('src', resim );
              //  var text = "~/Upload/"
              ////  var Rs = $("#TxtSrc").html('"' + text + data.img + '"');

              //var birlesik=  text.concat("", data.img);
              //  var Rem = $('#TxtResim').attr(src, birlesik);
              //  $('#Rsm').append(Rem);

               /* var YRs = $(Rs).html("'" + Rs + "'");*/
                //$('#UrunId').keydown(function () {
                //    $('#TxtResim').attr('src',text+data.img)

                //})
              /*  document.getElementById('TxtResim').src = document.getElementById('#TxtSrc').val();*/

                //var Ys = "~/Upload/ + data.img";
              /*  $("#TxtResim").attr('src', Rs);*/
                //$("#TxtResim").attr('src', function() {
                //    $("#TxtResim").attr('src').append(Rs)
                //});

              


                //$('#TxtResim').attr('src', function () {
                //    Rs.val();
                //} );


              //  var Yeni = data.img
              //var Son=  Resim.append(Yeni);
                //$("#TxtResim").attr('src', '').promise().done(function() {
                //    $(this).attr('src', '"' + Rs + '"' )
                //})
               

               
                


   
            },
            error: function (data) {
                alert("Bu ıd'ye ait veri yok");
            }

        });

    });

}

function AdaGoreUrunListele() {
    $("#BtnAdaGoreUrunListele").click(function () {
        var UrunAdi = $("#UrunAdi").val();
        $.ajax({

            url: '/Home/AdinaGoreUrunListele/' + UrunAdi,
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                $("#TxtUrunAdi").html(data.UrunAdi);
                $("#TxtUrunFiyati").html(data.UrunFiyati);

            },
            error: function (data) {
                alert("Bu ürün adına ait veri yok");
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
            success: function (data) {
                $.each(data, function (i, item) {
                    $("#TumUrunler").append(
                        //"<div> <ul>" + "<li>Ürün Adı: "
                        //+ item.UrunAdi + "     " + "Ürün Fiyatı: " + item.UrunFiyati + "</li>" +
                        //"<br/></ul></div>"

                        "<div><table><tr><strong>" + "Ürün Adı: " + item.UrunAdi + " - Ürün Fiyatı: " + item.UrunFiyati + " - Ürün Kategorisi : " + item.UrunKategorisi + "</tr></table></strong></div>"
                    );

                })

            },
            error: function (data) {
                alert("Buraya ait veri yok");
            }

        });

    });
    

}



function ElmaBilgileriGetir() {
    $("#BtnElmaBilgileri").click(function () {
        var Id = 1;
        $.ajax({

            url: '/Home/ElmaBilgileriGetir/' + Id,
            type: 'POST',
            dataType: 'json',
            success: function (data) {
                $("#LblElmaAdi").append(data.UrunAdi);
                $("#LblElmaFiyati").append(data.UrunFiyati).append("TL")
                $("#LblElmaKategorisi").append(data.UrunKategorisi);

            },  
            error: function (data) {
                alert("Bu ıd'ye ait veri yok");
            }

        });

    });

}


function UzumBilgileriGetir() {
    $("#BtnUzumBilgileri").click(function () {
        var Id = 3;
        $.ajax({

            url: '/Home/UzumBilgileriGetir/' + Id,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                $("#LblUzumAdi").append(data.UrunAdi);
                $("#LblUzumFiyati").append(data.UrunFiyati).append("TL");
                $("#LblUzumKategorisi").append(data.UrunKategorisi);

            },
            error: function (data) {
                alert("Bu ıd'ye ait veri yok");
            }

        });

    });

}


function UrunBilgileriGetir() {
    $("#BtnUrunBilgileri").click(function () {
       /* var Id = 1002;*/
        $.ajax({

            url: '/Home/UrunBilgileriGetir/' + Id,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                $("#LblErikAdi").append(data.UrunAdi);
                $("#LblErikFiyati").append(data.UrunFiyati).append("TL");
                $("#LblErikKategorisi").append(data.UrunKategorisi);

            },
            error: function (data) {
                alert("Bu ıd'ye ait veri yok");
            }

        });

    });

}


function ErikBilgileriGetir() {
    $("#BtnErikBilgileri").click(function () {
        var Id = 1002;
        $.ajax({

            url: '/Home/ErikBilgileriGetir/' + Id,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                $("#LblErikAdi").append(data.UrunAdi);
                $("#LblErikFiyati").append(data.UrunFiyati).append("TL");
                $("#LblErikKategorisi").append(data.UrunKategorisi);

            },
            error: function (data) {
                alert("Bu ıd'ye ait veri yok");
            }

        });

    });

}


function LimonBilgileriGetir() {
    $("#BtnLimonBilgileri").click(function () {
        var Id = 1003;
        $.ajax({

            url: '/Home/LimonBilgileriGetir/' + Id,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                $("#LblLimonAdi").append(data.UrunAdi);
                $("#LblLimonFiyati").append(data.UrunFiyati).append("TL");
                $("#LblLimonKategorisi").append(data.UrunKategorisi);

            },
            error: function (data) {
                alert("Bu ıd'ye ait veri yok");
            }

        });

    });

}


function AhududuBilgileriGetir() {
    $("#BtnAhududuBilgileri").click(function () {
        var Id = 1022;
        $.ajax({

            url: '/Home/AhududuBilgileriGetir/' + Id,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                $("#LblAhududuAdi").append(data.UrunAdi);
                $("#LblAhududuFiyati").append(data.UrunFiyati).append("TL");
                $("#LblAhududuKategorisi").append(data.UrunKategorisi);

            },
            error: function (data) {
                alert("Bu ıd'ye ait veri yok");
            }

        });

    });

}


function HavucBilgileriGetir() {
    $("#BtnHavucBilgileri").click(function () {
        var Id = 1004;
        $.ajax({

            url: '/Home/HavucBilgileriGetir/' + Id,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                $("#LblHavucAdi").append(data.UrunAdi);
                $("#LblHavucFiyati").append(data.UrunFiyati).append("TL");
                $("#LblHavucKategorisi").append(data.UrunKategorisi);

            },
            error: function (data) {
                alert("Bu ıd'ye ait veri yok");
            }

        });

    });

}


