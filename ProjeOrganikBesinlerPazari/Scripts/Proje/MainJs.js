var BtnLogin = document.getElementById('BtnLogin');

function Login() {
    if (BtnLogin !== undefined) {

       /* BtnLogin.setAttribute("disabled", "");*/
       /* BtnLogin.innerText = "Giriş yapılıyor...";*/
        var KullaniciAdi = document.getElementById('TxtKullaniciAdi').value;
        var Sifre = document.getElementById('TxtSifre').value;
        if (KullaniciAdi === '' || Sifre === '') {
            ShowAlert('info', 'Hata', 'Her iki alanı doldurun');
        }
        else {
            $.ajax({
                url: "/Api/Login",
                success: function (result, e, f) {
                    if (f.status === 200) {
                        alert("Başarıyla giriş yaptınız");
                        
                       
                        alert("Hoşgeldiniz " + KullaniciAdi);
                        if (result != "") {
                            /*window.location.href = "/Home/SepetDetay"; *//*Burdaki fark giriş yapan kullanıcının adı kutucukta yazacak ve sepettealışveriş yapabilecek*/
                            var KullaniciIsmi = document.getElementById('LblKullaniciIsmi2');
                            var BtnKullaniciIsmi = document.getElementById('BtnKullaniciIsmii');
                            KullaniciIsmi.innerText = " "+ KullaniciAdi ;
                            BtnKullaniciIsmi.value = "Hoşgeldiniz "+KullaniciAdi;
                            //var DvKaybol = document.getElementById('Kaybol');
                            //DvKaybol.style.display = "none";
                            window.location.href = "/Product/Index";
                           
                        }
                    }
                    else {
                        ShowAlert('error', 'Hata', 'Hatalı bilgi girişi yaptın');
                    }
                },
                data: { "KullaniciAdi": KullaniciAdi, "Sifre": Sifre },
                method: "POST"
            }).fail(function (result, e, f) {
                if (result.status === 500) {
                    ShowAlert('error', 'Hata', 'Hatalı bilgi girişi gerçekleşti');
                }
            }).catch(function (result, e, f) {
                var h = result;
            }).progress(function (result, e, f) {
                var y = result;
            }).finally(   function () {
                var BtnKullaniciIsmi = document.getElementById('BtnKullaniciIsmi');
                BtnKullaniciIsmi.value = "<b>" + result.data.Ad + "</b>";
            });
        }
    }

}




//function GetUserDetails() {
//    $.ajax({
//        url: "/Api/GetUserDetails",
//        success: function (result, e, f) {
//            if (result!=null) {
//                 if (f.status === 200) {
//                var BtnKullaniciIsmi = document.getElementById('BtnKullaniciIsmii');
//                BtnKullaniciIsmi.value = "<b>" + result.data.Ad + "</b>";
                
//                //var LblWelcome = document.getElementById('LblWelcome');
//                //LblWelcome.innerText = "Merhaba " + result.Ad + " " + result.Soyad;
//            }
//            }
           
//            else {
//                ShowAlert('error', 'Hata', 'Hatalı bilgi girişi');
//            }
//        },
//        method: "GET"
//    }).fail(function (result, e, f) {
//        if (result.status === 500) {
//            ShowAlert('error', 'Hata', 'Hatalı bilgi girişi');
//        }
//    }).catch(function (result, e, f) {
//        var h = result;
//    }).progress(function (result, e, f) {
//        var y = result;
//    });

//}



var BtnRegister = document.getElementById('BtnRegister');

function Register() {
    if (BtnRegister !== undefined) {

        var Ad = document.getElementById('TxtKisiAdi').value;
        var Soyad = document.getElementById('TxtKisiSoyadi').value;
        var DogumTarihi = document.getElementById('TxtDogumTarihi').value;
        var Tc = parseInt( document.getElementById('TxtTC').value);
        var KullaniciAdi = document.getElementById('TxtKullaniciAdi').value;
        var Sifre = document.getElementById('TxtSifre').value;
        var Adres = document.getElementById('TxtAdres').value;  //adresbaşlığınıemail olarak kullanıyorum tabloyu güncelleyene kadar
        var AdresBasligi = document.getElementById('TxtEmail').value;
        if (Ad === '' || Soyad === '' || DogumTarihi === '' || Tc === '' || KullaniciAdi === '' || Sifre === '' || Adres === '' || AdresBasligi === '' ) {
            ShowAlert('info', 'Hata', 'Tüm alanları doldurunuz');
        }
        else {
            $.ajax({
                url: "/Api/Register",
                success: function (result, e, f) {
                    if (f.status  === 200) {
                        if (result != "") {
                            window.location.href = "/Home/Index";  //sepet sayfasını yaptıktan sonra üyelikten sonra sepete yönlendireilirsin
                            //if (result.status === 200) {
                            //    ShowAlert('success', 'Tebrikler', 'Kayıt başarılı şekilde gerçekleştirildi');
                            //}
                        }
                    }
                    else {
                        ShowAlert('error', 'Hata', 'Hatalı bilgi girişi var');
                    }
                },
                data: { "Ad": Ad, "Soyad": Soyad, "DogumTarihi": DogumTarihi, "Tc": Tc, "KullaniciAdi": KullaniciAdi, "Sifre": Sifre, "Adres": Adres, "AdresBasligi": AdresBasligi },
               
                method: "POST"
            }).done(function (result, e, f) {
                var f = result;
            }).fail(function (result, e, f) {
                if (result.status === 500) {
                    ShowAlert('success', 'Basarili', 'Üylelik kaydedildi');//HATA !! database'e kaydolmasına rağmen dönerken hataya düşüyor successe düşürülmesigerekli, bir desweet alert sayfa sonunda csssizçalışıyor
                    window.location.href = "/Home/Index";
                } 
            }).catch(function (result, e, f) {
                var h = result;
            }).progress(function (result, e, f) {
                var y = result;
            }).finally(function (result, e, f) {
                if (result.status === 200) {
                    ShowAlert('success', 'Tebrikler', 'Kayıt başarılı şekilde gerçekleştirildi');
                }
            });
        }
    }

}











//success - error - warning - info - question
function ShowAlert(picon, ptitle, ptext) {

    Swal.fire({
        icon: picon,
        title: ptitle,
        text: ptext
    });

}