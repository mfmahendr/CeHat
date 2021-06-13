## Developer
Aplikasi ini dibuat sebagai tugas akhir dari Praktikum Pemrograman Berorientasi Objek.
1. M. Fadhil Mahendra (20/460550/TK/51139)
2. M. Iqbal Masykuri  (20/460555/TK/51144)

> ---
>
><nav>
>
> ##### Navigasi
> 
> - <a href="#cehat">CeHat</a></li>
>    -  <a href="#pengenalan">Introduksi</a>
>    - <a href="#classDiagram">Class Diagram</a>
>    - <a href="#database">Diagram Basis Data</a>
> - <a href="#petunjuk">Petunjuk Penggunaan</a>
>      - <a href="#admin">Administrator</a>
>        - <a href="#data">1) Mengelola Data di Menu Admin, Penyakit, Gejala, dan Obat</a>
>        - <a href="#rules">2) Mengelola <i>Rules</i> di Menu Aturan Gejala dan Aturan Obat</a>
>      - <a href="#pengguna">Pengguna</a>
>         - <a href="#diagnosis">Melakukan Diagnosis</a>
>         - <a href="#rating">Memberi Rating</a>
> 
> </nav>
> 
> ---

<h1 id="cehat">CeHat</h1>
<h2 id="pengenalan">Introduksi</h2>

**CeHat** merupakan aplikasi cek kesehatan yang dapat diakses melalui desktop dengan fungsi utama untuk mendiagnosis penyakit yang sedang dialami oleh seseorang berdasarkan jawaban atas pertanyaan yang terkait gejala-gejala yang sedang dialaminya.


<h2 id="classDiagram">Class Diagram</h2>

![image](https://user-images.githubusercontent.com/71614957/115813677-cde0ca00-a41d-11eb-93ed-aeb7adc5ff44.png)

<h2 id="database">Diagram Basis Data</h2>

![EntityDesignerDiagram](https://user-images.githubusercontent.com/71614957/121780787-10c45000-cbcc-11eb-8f9b-39e9152a6af2.jpg)


<h1 id="petunjuk">Petunjuk Penggunaan</h1>

Sebelum menggunakan aplikasi, **penting** untuk diketahui bahwa database yang dipakai dalam aplikasi ini merupakan _local database_ sehingga Anda harus memiliki DBMS-nya (dalam hal ini, SQL Server). Pertama yang perlu Anda lakukan adalah membuka aplikasi, tunggu hingga proses loading aplikasinya selesai. Setelah proses loading selesai, maka akan muncul tombol "Masuk". Klik tombol masuk tersebut sehingga muncul dua opsi untuk menggunakan aplikasinya, Anda dapat memilih login ke aplikasi sebagai Administrator atau sebagai Pengguna biasa, Anda dapat memilih salah satu opsi. Selanjutnya ikuti petunjuk penggunaan berikut sesuai dengan opsi masuk yang Anda pilih.

<h2 id="admin">Administrator</h2>

Administrator dalam berperan untuk mengelola informasi yang diperlukan agar proses diagnosis sesuai dengan luaran yang diharapkan. Administrator dapat menambah, menghapus, dan mengubah informasi penyakit, gejala-gejalanya, alternatif obat, dan berbagai *rules* yang sudah disepakati oleh para pakar kesehatan. Untuk dapat mengaksesnya, Anda harus *login* terlebih dahulu menggunakan akun admin yang Anda miliki. Berikut adalah petunjuk untuk login.
1. Login dengan *username* dan *password* Anda. Masukkan *username* dan *password* Anda, kemudian klik tombol masuk.
2. Jika Anda berhasil masuk ke dalam aplikasi, akan terdapat 6 buah menu seperti tertampil pada gambar bawah. Menu tersebut terdiri atas menu admin, gejala, penyakit, obat, aturan gejala dan aturan obat.

<h4 id="data">1) Mengelola Data di Menu Admin, Penyakit, Gejala, dan Obat</h4>

##### Mencari Data
Untuk mencari data pada tabel, Anda dapat mencarinya dengan hanya mengetikkan data yang ingin di cari pada kotak pencarian dan secara *real-time* data akan terfilter berdasarkan apa yang Anda ketikkan.

##### Menambahkan Data
Untuk dapat menambahkan data, Anda dapat mengikuti langkah-langkah sebagai berikut.
1. Masukkan informasi data pada *text box* yang terletak di bagian sebelah kiri *form* aplikasi.
2. Jika informasi sudah diisi di dalam *text box*, klik tombol "Tambah" untuk menambahkan informasi yang telah Anda isi di dalam *text box*. Jika tombol "Tambah" tidak bisa diklik, maka tekan tombol "Refresh" yang ada.
3. Apabila setelah diklik, informasi yang Anda masukkan bertambah di dalam tabel, maka data yang Anda masukkan sudah ditambahkan.
4. Apabila muncul galat, maka informasi yang Anda masukkan gagal ditambahkan. Hal ini dapat terjadi karena beberapa hal, maka perhatikan beberapa catatan penting yang perlu ketika sedang menambahkan data.

Terdapat beberapa **catatan penting** yang harus Anda perhatikan ketika menambahkan data: 
1. Pastikan bahwa setiap *text box* terisi ketika akan menambahkan data pada *form* penyakit dan gejala. Adapun untuk menambahkan informasi mengenai obat, nama obat tidak boleh kosong, sedangkan dosis obat dan efek sampingnya boleh Anda kosongkan.
2. Pastikan bahwa isian pada *text box* tidak boleh didahului oleh spasi karena masukan tidak akan bisa ditambahkan.
##### Menghapus Data
Berikut adalah langkah-langkah yang perlu Anda ikuti untuk menghapus data yang ada di dalam tabel informasi.
1. Pilih data yang ingin Anda hapus pada tabel dengan cara mengeklik baris data yang akan dihapus.
2. Perhatikan bahwa data yang Anda pilih akan tertampil di dalam *text box*. Pastikan bahwa data tersebut adalah data yang memang ingin Anda hapus.
3. Klik tombol "Hapus" dan data akan terhapus. Perlu Anda ketahui bahwa pada awalnya, tombol hapus tidaklah aktif (tidak bisa diklik). Tombol tersebut akan aktif jika Anda memilih baris data pada tabel.
##### Mengubah Data
Berikut adalah langkah-langkah yang perlu Anda ikuti untuk mengubah data yang ada di dalam tabel informasi.
1. Pilih data yang ingin Anda hapus pada tabel dengan cara mengeklik baris data yang akan diubah.
2. Perhatikan bahwa data yang Anda pilih akan tertampil di dalam *text box*. Pastikan bahwa data tersebut adalah data yang memang ingin Anda ubah.
3. Ubah *text box* yang berisi data informasi yang telah dipilih dengan informasi baru. Jika Anda tidak ingin mengubah data suatu elemen informasi, maka hapus dan kosongkan informasi yang sudah terisi pada *text box* tersebut.
4. Klik tombol "Ubah" dan data akan berubah. Sama halnya dengan tombol "Hapus", pada awal nya, tombol ubah tidak akan aktif (tidak bisa diklik) hingga Anda memilih suatu baris data pada tabel.
5. Jika data gagal diubah, maka perhatikanlah pesan yang muncul.
   
<h4 id="rules">2) Mengelola <i>Rules</i> di Menu Aturan Gejala dan Aturan Obat</h4>

Sebenarnya, pengelolaan *rules* tidak jauh berbeda dengan pengelolaan pada data informasi. Yang menjadi perbedaan besar antara keduanya adalah tidak tersedianya fitur ubah ketika Anda mengelola *rules*.

##### Mencari Data Gejala atau Obat
Untuk mencarinya, Anda dapat mengetikkan data (baik gejala pada menu Aturan gejala maupun obat pada menu Aturan Obat) yang ingin di cari pada kotak pencarian dan secara *real-time* data akan terfilter berdasarkan apa yang Anda ketikkan.

##### Menambahkan *rules*
Untuk menambahkan *rules*, Anda dapat mengikuti langkah-langkah sebagai berikut.
1. Pilih penyakit di *combo box* penyakit yang ingin Anda tambahkan.
2. Pilih gejala atau obat (tergantung di menu apa Anda berada) di *combo box*-nya yang ingin Anda tambahkan.
3. Klik tombol "Tambah" untuk menambahkan *rules* yang telah Anda pilih. Jika tombol "Tambah" tidak bisa diklik, maka tekan tombol "Refresh" yang ada untuk mengaktifkannya.
4. Apabila setelah diklik, informasi id penyakit beserta informasi gejala/obat yang Anda masukkan bertambah di dalam tabel, maka data yang Anda masukkan sudah ditambahkan.
5. Apabila *rules* gagal ditambahkan, maka pahamilah pesan yang muncul.

##### Menghapus *rules*
Berikut adalah langkah-langkah untuk menghapus rules.
1. Pilih data yang ingin Anda hapus pada tabel dengan cara mengeklik baris data yang ingin dihapus.
2. Perhatikan bahwa data yang Anda pilih akan tertampil di dalam *text box*. Pastikan bahwa data tersebut adalah data yang memang ingin Anda hapus.
3. Klik tombol "Hapus". Perlu diketahui bahwa pada awal nya, tombol tersebut tidak aktif (tidak bisa diklik), tombol akan aktif jika Anda memilih suatu baris data pada tabel.
4. Apabila baris data yang Anda klik sebelumnya hilang pada tabel, maka data berhasil dihapus.
   

<h2 id="pengguna">Pengguna</h2>

Untuk masuk ke dalam menu utama, pengguna akan diminta memasukkan nama terlebih dahulu di dalam *text box*. Setelah diisi, klik "Masuk" dan Anda akan diarahkan ke menu utama. Pada menu utama ini, terdapat tiga buah menu, yakni menu diagnosis, rating, dan menu tentang aplikasi.


<h4 id="diagnosis">Melakukan Diagnosis</h4>

Langkah-langkah untuk melakukan diagnosis adalah sebagai berikut.

1. Masuk ke menu diagnosis
2. Pilih gejala yang sedang Anda alami dengan *checklist* gejala
3. Setelah memilih gejala, klik tombol "Submit"
4. Diagnosis berhasil apabila informasi penyakit dan alternatif obat ditampilkan pada hasil diagnosis.
5. Setelah hasil ditampilkan Anda bisa mengulangi diagnosis dengan klik pada tombol "Ulangi" dan Anda bisa kembali ke menu utama dengan klik pada tombol "Menu"


<h4 id="rating">Memberi Rating</h4>

Anda bisa memberikan *rating* atau memberi kesan, pesan, kritik, ataupun saran mengenai aplikasi dengan klik menu rating, memilih rating aplikasi pada *combo box* dan mengisi *text box* "kritik dan saran", kemudian klik submit.
