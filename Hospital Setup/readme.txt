Öncelikle veritabanını kur.


Veritabanı kurmak için

	1. mssql'i aç databases'e sağ tıkla
	2. restore database'i seç
	3. device'i seç 
	4. addd yapıp database(db.bak)' ı seç üstüne tıklma mavi olsun add yap tamama bas
	5. altta databaseyi görünce databasenin adına tıkla OK' a bas kur


---------------------------------------------------------------------------------------------------------------------------------------------------------------

Veritabanını hallettikten sonra;
	
	1.
		a-) 	C:\ diskine dbYol.txt dosyasını at (Direk C diskinde olacak herhangi bir alt klasöre kurma)
		b-) 	C:\dbYol.txt (bu şekilde olacak)

	2.
		Sunucu ismini öğren.
		Sunucu ismini öğren öğrenmek için;
		Sql serveri aç. Database klasörünün üstündeki siyah logolu kısıma sağ tıkla en altta Properties kısmına tıkla
		açılan pencerede Name kısmında yazan Server adını kopyala ardından
		-->	
	
	3. 
		dbYol.txt nin içindeki
		Data Source=   xxxx   ;Initial Catalog=GProjeHastane;Integrated Security=True 
		yazan yerde xxxx kısmında yazan yerdeki server adını silip kopyaladığın sertver adını yapıştır.
		xxxx( = ile ; arasına olucak).

------------------------------------------------------------------------------------------------------------------------------------------------------------------
Yolu halletikten sonra;
	1.
		setupa gel setup.exe'ye bas uygulamayı kur.
	Son...

Uyarı!!! --> Hizmetlerde mssqlin çalıştığına emin ol 
 



