-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: 22 Jan 2018 pada 03.37
-- Versi Server: 10.1.10-MariaDB
-- PHP Version: 5.6.19

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `keuangan`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `member`
--

CREATE TABLE `member` (
  `id` int(11) NOT NULL,
  `nim` varchar(45) NOT NULL,
  `nama` varchar(45) DEFAULT NULL,
  `jurusan` varchar(45) DEFAULT NULL,
  `noHp` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `member`
--

INSERT INTO `member` (`id`, `nim`, `nama`, `jurusan`, `noHp`) VALUES
(2, '1510520044', 'rian', 'D3 TI', '081917876555'),
(5, '1510530012', 'noval', 'S1 TI', '08312942828'),
(6, '1510530166', 'ulala', 'D3 MI', '08990998'),
(7, '15104499', 'lalal', 'S1 TI', '09088'),
(8, '19999', 'uya', 'D3 TI', '0'),
(9, '109090', 'uya', 'S1 TI', '0909090'),
(10, 'ksdur', 'iiii', 'S1 TI', '00');

-- --------------------------------------------------------

--
-- Struktur dari tabel `pemasukan`
--

CREATE TABLE `pemasukan` (
  `id` int(11) NOT NULL,
  `uang` double DEFAULT NULL,
  `tanggal` date DEFAULT NULL,
  `pengurus_id` int(11) NOT NULL,
  `member_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `pemasukan`
--

INSERT INTO `pemasukan` (`id`, `uang`, `tanggal`, `pengurus_id`, `member_id`) VALUES
(18, 5000, '2017-07-08', 3, 2),
(20, 5000, '2017-07-11', 2, 5),
(21, 2000, '2017-07-11', 1, 6),
(23, 2000, '2017-07-12', 1, 5),
(24, 5000, '2017-07-12', 3, 5),
(34, 6000, '2018-01-19', 3, 5),
(35, 10000, '2018-01-20', 1, 5),
(36, 5000, '2018-01-19', 1, 8);

-- --------------------------------------------------------

--
-- Struktur dari tabel `pengeluaran`
--

CREATE TABLE `pengeluaran` (
  `id` int(11) NOT NULL,
  `uang` double NOT NULL,
  `tanggal` date DEFAULT NULL,
  `keterangan` varchar(50) DEFAULT NULL,
  `pengurus_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `pengeluaran`
--

INSERT INTO `pengeluaran` (`id`, `uang`, `tanggal`, `keterangan`, `pengurus_id`) VALUES
(1, 2500, '2017-07-08', 'Jilid', 2),
(3, 1000, '2017-07-12', 'selotip', 3),
(5, 1000, '2018-01-20', 'beli isolasi', 1),
(6, 9000, '2018-01-12', 'print proposal', 1),
(7, 1000, '2018-01-20', 'print surat', 1);

-- --------------------------------------------------------

--
-- Struktur dari tabel `pengurus`
--

CREATE TABLE `pengurus` (
  `id` int(11) NOT NULL,
  `nim` varchar(45) NOT NULL,
  `nama` varchar(45) DEFAULT NULL,
  `jurusan` varchar(45) DEFAULT NULL,
  `username` varchar(25) NOT NULL,
  `password` varchar(45) DEFAULT NULL,
  `noHp` varchar(45) DEFAULT NULL,
  `jabatan` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data untuk tabel `pengurus`
--

INSERT INTO `pengurus` (`id`, `nim`, `nama`, `jurusan`, `username`, `password`, `noHp`, `jabatan`) VALUES
(1, '1510520036', 'irfi', 'TI', 'irfi', 'irfi', '082339xxxxxx', 'Ketua Umum'),
(2, '1510510031', 'noval', 'TI', 'noval', 'noval', '083129xxxxxx', 'Tutor DKV'),
(3, '1510510033', 'rian', 'TI', 'rian', 'rian', '081917xxxxxx', 'Wakil Ketua'),
(4, '1310520032', 'ade', 'S1 TI', 'ade', 'ade', '082339xxxxxx', 'Mentor D3 TI'),
(5, '1410520198', 'yusha', 'S1 TI', 'yusha', 'yusha', '0000', 'Bendahara'),
(7, '15104499', 'lalal', 'S1 TI', 'lalal', '09088', 'lalal', 'Mentor S1 DKV'),
(9, '109090', 'uya', 'S1 TI', 'uya', '0909090', 'uya', 'Mentor D3 MI');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `member`
--
ALTER TABLE `member`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `nim` (`nim`);

--
-- Indexes for table `pemasukan`
--
ALTER TABLE `pemasukan`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_pemasukan_member` (`member_id`),
  ADD KEY `fk_pemasukan_pengurus` (`pengurus_id`);

--
-- Indexes for table `pengeluaran`
--
ALTER TABLE `pengeluaran`
  ADD PRIMARY KEY (`id`),
  ADD KEY `fk_pengeluaran_pengurus` (`pengurus_id`);

--
-- Indexes for table `pengurus`
--
ALTER TABLE `pengurus`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `member`
--
ALTER TABLE `member`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
--
-- AUTO_INCREMENT for table `pemasukan`
--
ALTER TABLE `pemasukan`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=37;
--
-- AUTO_INCREMENT for table `pengeluaran`
--
ALTER TABLE `pengeluaran`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;
--
-- AUTO_INCREMENT for table `pengurus`
--
ALTER TABLE `pengurus`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;
--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `pemasukan`
--
ALTER TABLE `pemasukan`
  ADD CONSTRAINT `fk_pemasukan_member` FOREIGN KEY (`member_id`) REFERENCES `member` (`id`) ON UPDATE CASCADE,
  ADD CONSTRAINT `fk_pemasukan_pengurus` FOREIGN KEY (`pengurus_id`) REFERENCES `pengurus` (`id`) ON UPDATE CASCADE;

--
-- Ketidakleluasaan untuk tabel `pengeluaran`
--
ALTER TABLE `pengeluaran`
  ADD CONSTRAINT `fk_pengeluaran_pengurus` FOREIGN KEY (`pengurus_id`) REFERENCES `pengurus` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
