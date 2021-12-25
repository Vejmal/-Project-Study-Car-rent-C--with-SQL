-- phpMyAdmin SQL Dump
-- version 4.7.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Czas generowania: 03 Gru 2019, 22:53
-- Wersja serwera: 10.1.29-MariaDB
-- Wersja PHP: 7.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Baza danych: `wypozyczarka`
--

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `klienci`
--

CREATE TABLE `klienci` (
  `idKlienta` int(11) NOT NULL,
  `Login` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_polish_ci NOT NULL,
  `Hasło` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL,
  `Imie` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_polish_ci NOT NULL,
  `Nazwisko` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_polish_ci NOT NULL,
  `NumerTelefonu` int(9) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_polish_ci;

--
-- Zrzut danych tabeli `klienci`
--

INSERT INTO `klienci` (`idKlienta`, `Login`, `Hasło`, `Imie`, `Nazwisko`, `NumerTelefonu`) VALUES
(1, 'Adrian', '1234', 'Adrian', 'Adamowicz', 510542698);

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `naszesamochody`
--

CREATE TABLE `naszesamochody` (
  `idSamochodu` int(11) NOT NULL,
  `Marka` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_polish_ci DEFAULT NULL,
  `Model` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_polish_ci DEFAULT NULL,
  `Kolor` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_polish_ci DEFAULT NULL,
  `Rocznik` int(11) DEFAULT NULL,
  `Silnik` varchar(40) NOT NULL,
  `Moc` int(11) NOT NULL,
  `od 0 do 100` varchar(40) NOT NULL,
  `Ilosc miejsc` int(11) NOT NULL,
  `CenaZaGodzine` float DEFAULT NULL,
  `CzyNaStanie` enum('tak','nie') CHARACTER SET utf8mb4 COLLATE utf8mb4_polish_ci DEFAULT 'tak'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Zrzut danych tabeli `naszesamochody`
--

INSERT INTO `naszesamochody` (`idSamochodu`, `Marka`, `Model`, `Kolor`, `Rocznik`, `Silnik`, `Moc`, `od 0 do 100`, `Ilosc miejsc`, `CenaZaGodzine`, `CzyNaStanie`) VALUES
(37, 'Ferrari', 'Enzo', 'Czerwony', 2012, 'V8', 780, '1.5', 2, 700, 'tak'),
(40, 'Lamborghini', 'Aventador SV', 'Żółty', 2015, '6.5 V12', 750, '2.8', 3, 1000, 'tak'),
(41, 'Lamborghini ', 'Urus', 'Czarny', 2013, '4.0V8', 650, '3,6', 5, 600, 'tak'),
(42, 'Lamborghini', 'Huracan Performante', 'Czarny', 2016, '5.2V10', 690, '2.9', 2, 950, 'tak'),
(43, 'McLaren', '720s', 'Srebny', 2013, '4.0V8 biturbo', 720, '2,9', 2, 1100, 'tak'),
(44, 'Aston Martin', 'Vanquish', 'Srebny', 2015, '6.0 V12', 570, '3.8', 5, 700, 'tak'),
(45, 'Ferrari ', 'Portofino', 'Czerwony', 2017, '3.9 V8', 600, '3.5', 2, 700, 'tak'),
(46, 'Maserati ', 'GranCabrio MC', 'Srebny', 2015, '4.7 V8', 480, '4.9', 5, 500, 'tak'),
(47, 'FERRARI ', '488 GTB', 'Czerwony', 2016, '3.9 V8 Turbo', 670, '3.0', 2, 850, 'tak'),
(48, 'Chevrolet ', 'Corvette ZR1', 'Błekitny', 2017, '6.2 LT5 V8', 755, '3.1', 2, 900, 'tak'),
(49, 'Chevrolet ', 'Camaro ZL1', 'Żółty', 2014, '6.2 LT4 V8 kompresor', 640, '3.5', 5, 700, 'tak'),
(50, 'Porsche ', '911 Turbo S Cabrio', 'Biały', 2012, '3.8 B6', 580, '3', 5, 800, 'tak'),
(51, 'Porsche ', '911 Turbo S', 'Niebieski', 2016, '3.8 B6', 580, '2.9', 5, 900, 'tak'),
(52, 'Porsche ', '911 4S Cabrio', 'Czarny', 2017, '3.0 boxer6', 420, '4,5', 5, 900, 'tak'),
(53, 'Porsche ', 'Panamera Turbo 2016', 'Brązowy', 2016, 'V8', 550, '3.8', 5, 900, 'tak'),
(54, 'NISSAN', 'GT-R Nismo', 'Błekitny', 2018, '3.8 V6 TURBO', 600, '2.7', 5, 750, 'tak'),
(55, 'BMW', 'I8', 'Błekitny', 2012, '1.5 R3', 388, '4.2', 5, 450, 'tak'),
(56, 'Mercedes ', 'AMG S63 Cabrio', 'Biały', 2017, '5.5', 670, '3.7', 5, 650, 'tak'),
(57, 'Mercedes ', 'E63 AMG S', 'Szary', 2014, '4.0 V8 Biturbo', 670, '3.4', 5, 780, 'tak'),
(58, 'Maserati', 'Quattroporte S Q4', 'Czarny', 2015, '3.0 V6', 410, '4.9', 5, 700, 'tak'),
(59, 'Mercedes ', 'G500 AMG', 'Czarny', 2012, '4.0 V8', 422, '5.9', 5, 800, 'tak'),
(60, 'Maserati', 'Levante', 'Pomarańczowy', 2015, '3.0 V6', 470, '5.2', 5, 550, 'tak'),
(61, 'BMW ', '740d xDrive', 'Szary', 2016, '3.0 R6', 320, '5.3', 5, 600, 'tak'),
(62, 'FORD', 'FIESTA PROTO', 'Fiolet', 2018, '2.0 R4 Turbo', 690, '2.3', 5, 900, 'tak');

-- --------------------------------------------------------

--
-- Struktura tabeli dla tabeli `wypozyczenia`
--

CREATE TABLE `wypozyczenia` (
  `idWypozyczenia` int(11) NOT NULL,
  `idSamochodu` int(11) NOT NULL,
  `idKlienta` int(11) NOT NULL,
  `Data Od` datetime NOT NULL,
  `Data Do` datetime NOT NULL,
  `KosztWynajmu` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Zrzut danych tabeli `wypozyczenia`
--

INSERT INTO `wypozyczenia` (`idWypozyczenia`, `idSamochodu`, `idKlienta`, `Data Od`, `Data Do`, `KosztWynajmu`) VALUES
(5, 37, 1, '2019-11-19 06:00:00', '2019-11-20 05:00:00', 0);

--
-- Indeksy dla zrzutów tabel
--

--
-- Indexes for table `klienci`
--
ALTER TABLE `klienci`
  ADD PRIMARY KEY (`idKlienta`),
  ADD UNIQUE KEY `idKlienta_UNIQUE` (`idKlienta`);

--
-- Indexes for table `naszesamochody`
--
ALTER TABLE `naszesamochody`
  ADD PRIMARY KEY (`idSamochodu`),
  ADD UNIQUE KEY `idSamochodu_UNIQUE` (`idSamochodu`);

--
-- Indexes for table `wypozyczenia`
--
ALTER TABLE `wypozyczenia`
  ADD PRIMARY KEY (`idWypozyczenia`),
  ADD KEY `idSamochodu_idx` (`idSamochodu`),
  ADD KEY `idKlienta_idx` (`idKlienta`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT dla tabeli `klienci`
--
ALTER TABLE `klienci`
  MODIFY `idKlienta` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT dla tabeli `naszesamochody`
--
ALTER TABLE `naszesamochody`
  MODIFY `idSamochodu` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=63;

--
-- AUTO_INCREMENT dla tabeli `wypozyczenia`
--
ALTER TABLE `wypozyczenia`
  MODIFY `idWypozyczenia` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Ograniczenia dla zrzutów tabel
--

--
-- Ograniczenia dla tabeli `wypozyczenia`
--
ALTER TABLE `wypozyczenia`
  ADD CONSTRAINT `idKlienta` FOREIGN KEY (`idKlienta`) REFERENCES `klienci` (`idKlienta`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `idSamochodu` FOREIGN KEY (`idSamochodu`) REFERENCES `naszesamochody` (`idSamochodu`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
