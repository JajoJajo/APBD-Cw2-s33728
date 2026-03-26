# APBD-Cw2-s33728

Aplikacja konsolowa która symuluje wypożyczalnie sprzętu. Możliwe jest zarządzanie sprzętem, użytkownikami oraz procesem wypożyczenia i zwrotów.
Funkcjonalności:
Dodawanie użytkowników i sprzętu
Wypożyczanie sprzętu
Zwrot oraz naliczanie kary za opóźnione oddanie
Oznaczanie sprzętu jako niedostępny ze wzglądu na wypożycznie albo z jakiego innego powodu
Możliwość sprawdzenia wszystkich aktywnych wypożyczeni oraz aktywnych ale opóźnionych wypożyczeń
Generowanie prostego raportu


Zdecydowałem się na rozdzielenie projektu na 4 warstwy

1. Models
   Zawiera klasy reprezentujące dane i podstawowe zachowania
2. Exceptions
   Zawiera wszystkie używane wyjątki które dziedziczą po bazowym wyjątku RentException
3. Services
   Zawiera interfejsy oraz ich implementację które odpowiadaj ża operacje na danych oraz logikę biznesową
4. Program
   Program.cs odpowiada wyłącznie za demonstrację działania systemu i interakcję z użytkownikiem nie implementuje żadnych metod

Zdecydowałem się na taki podział projektu aby zminimalizować umieszczania logiki w jednej klasie, ułatwić rozwój i ewentualne zmiany w systemie


 
#Kohezja
Każda klasa ma jedną określoną odpowiedzialność:
* RentService – zarządza wypożyczeniami
* EquipmentService – zarządza sprzętem
* UserService – zarządza użytkownikami
* Rent – reprezentuje pojedyncze wypożyczenie

#Coupling
Ograniczyłem zależności między klasami poprzez:
* Użycie interfejsów
* nie tworzenia zależnoiści w klasach, serwisy nie tworzą innych serwisów

#Odpowiedzialność klas
* Klasy z folderu Models przechowują dane i najprostszą logikę w przypadku klasy Rent
* Serwisy zawierają całą logikę
* Program.cs odpowiada jedynie za uruchomienie testu

#Scenariusz demonstracyjny
W Program.cs zaprezentowano:
* dodanie sprzętu i użytkowników
* poprawne wypożyczenie
* próbę wypożyczenia niedostępnego sprzętu
* przekroczenie limitu wypożyczeń
* zwrot w terminie
* zwrot po terminie (z karą)
* raport końcowy
