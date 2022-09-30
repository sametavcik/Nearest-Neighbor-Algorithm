# Nearest-Neighbor-Algorithm

##  Bu proje, kullanıcıdan nokta sayısı,genişlik ve yükseklik boyutlarını alarak x,y düzleminde rastgele noktalar oluşturup rastgele seçilen bir nokta üzerinden tüm noktaları dolaşacak en kısa yolu bulmayı ve bu yolun uzunluğunu bulmayı amaçlamaktadır. 
![Adsız4](https://user-images.githubusercontent.com/65908597/193363467-9db3fa00-d928-4d70-9aa1-2eb40a96a066.png)

![image](https://user-images.githubusercontent.com/65908597/193361347-2cb07690-7908-4023-a644-fef372b80264.png)

* Uzaklık Matrisi (Distance Matrix-DM) Üretimi: Kendisine verilen nx2 noktalar matrisini nxn’lik uzaklık matrisine çeviren ve döndüren metot yazılır. Uzaklık matrisi (DM) her bir nokta çifti arasındaki uzaklık bilgisini içermektedir. Örneğin, DM[i,j] i ve j noktaları arasındaki mesafeyi verecektir. Uzaklıklar simetrik olduğundan DM[i,j]=DM[j,i] eşitliği sağlanacaktır (i’den j’ye uzaklık ile j’den i’ye uzaklık aynıdır). Tablo 1’de örnek bir uzaklık matrisi yer almaktadır.


![Adsız1](https://user-images.githubusercontent.com/65908597/193362974-57863cee-b5a8-4875-9470-3435f4e3dc82.png)
![Adsız5](https://user-images.githubusercontent.com/65908597/193363589-16429e53-0f2a-48e0-bc45-351d993af9b9.png)
* n = 20 için rastgele bir noktadan başlayarak tüm noktaları en yakın komşu yöntemine (nearest neighbor) göre dolaşan metod yazılmıştır. (En yakın komşu yöntemi, Öklid uzaklığına göre başlangıç noktasına en yakın noktayı bularak devam eder. Sonra, dolaşılmamış noktalar içinde bu yeni noktaya en yakın noktaya gider. Tüm noktalar dolaşılana kadar bu işlem devam eder ve turu tamamlar). Toplam yol uzunluğu hesaplanmıştır. Bu 10 farklı rastgele başlangıç noktası için tekrarlanmıştır ve 10 farklı tur için aşağıdaki bilgiler konsolda listelenmiştir.
* DM (uzaklık matrisi)
#### Her bir tur için:
* Tur numarası (1’den 10’a kadar)
* İlgili turda sırayla hangi numaralı noktalara uğradığı, (5-2-0-1-3-4 gibi),
* Turun toplam yol uzunluğu (5-2-0-1-3-4 turu çıktıysa uzaklıklar toplamı).

![Adsız6](https://user-images.githubusercontent.com/65908597/193364116-977cc15b-0dab-4d9e-a704-5bdda1483fec.png)
