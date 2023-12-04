-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Waktu pembuatan: 04 Des 2023 pada 19.01
-- Versi server: 10.4.28-MariaDB
-- Versi PHP: 8.0.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_ecomm`
--

-- --------------------------------------------------------

--
-- Struktur dari tabel `categories`
--

CREATE TABLE `categories` (
  `id` bigint(20) NOT NULL,
  `created_by` bigint(20) NOT NULL,
  `category_name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `categories`
--

INSERT INTO `categories` (`id`, `created_by`, `category_name`) VALUES
(1, 1, 'Food'),
(2, 1, 'Beverage'),
(3, 1, 'Handphone'),
(13, 1, 'Laptop'),
(14, 1, 'Powerbank');

-- --------------------------------------------------------

--
-- Struktur dari tabel `products`
--

CREATE TABLE `products` (
  `id` bigint(20) NOT NULL,
  `id_category` bigint(20) NOT NULL,
  `created_by` bigint(20) NOT NULL,
  `product_name` varchar(255) NOT NULL,
  `description` text NOT NULL,
  `stock` int(11) NOT NULL,
  `price` double NOT NULL,
  `image` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `products`
--

INSERT INTO `products` (`id`, `id_category`, `created_by`, `product_name`, `description`, `stock`, `price`, `image`) VALUES
(5, 3, 1, 'Huawei Mate 40 Pro', 'Huawei Mate 40 Pro 256GB with chipset Kirin 9000 5G (5nm), 6.76 inches', 11, 10999000, 'https://i.ibb.co/C6cDvc6/image.jpg'),
(6, 2, 1, 'Bubble Tea', 'Milktea combined with brown sugar and bobba as topping', 69, 21500, 'https://i.ibb.co/nPD0Gsb/image.jpg'),
(7, 2, 1, 'Melon Squash', 'The freshness of melon is combined with nata de coco, lemon slice, and soda', 118, 15999, 'https://i.ibb.co/CWXY0vN/image.jpg'),
(8, 1, 1, 'Ttteokbokki', 'Rice cakes from South Korean that paired with eomuk (fish cakes), scallions, and seasoned with either spicy gochujang (chili paste) or non-spicy ganjang.', 12, 20900, 'https://i.ibb.co/d4WnY6Y/image.jpg'),
(9, 1, 1, 'Ramen', 'Creamy Miso Ramen with Chicken Katsu', 23, 59999, 'https://i.ibb.co/b6qF3G6/image.jpg'),
(10, 13, 1, 'HP Lightly Used', 'HP Lightly Used 15 6 Rose Gold', 17, 12999999, 'https://i.ibb.co/kHjK1ns/image.jpg'),
(11, 3, 1, 'Samsung S22 Ultra', 'Samsung Galaxy S22 ultra 256GB Dynamic Amoled 2X with processor Qualcomm Snapdragon 8 Gen 1, 6.8 inch', 21, 14799000, 'https://i.ibb.co/Jq5kh7d/image.jpg'),
(12, 3, 1, 'iPhone 13 Pro', 'iPhone 13 Pro with 256GB capacity, 6.1-inch Super Retina XDR display with ProMotion for faster, A15 Bionic chip', 5, 14999000, 'https://i.ibb.co/t4vZjQt/image.jpg'),
(13, 13, 1, 'ASUS Vivobook', 'ASUS VivoBook 15X X1503ZA-L1236W 15_6_ OLED i5-12500H 16GB RAM 512GB SSD Windows 11 Home', 7, 9499000, 'https://i.ibb.co/vwJhKyV/image.jpg'),
(14, 2, 1, 'Spaghetti', 'Pasta spaghetti with grilled shrimps bechamel sauce. Spaghetti with seafood rich cream. Cooking mediterranean food with savory prawns, macro top view, blue table, italian cuisine, vertical', 123, 39900, 'https://i.ibb.co/YXpM21p/image.jpg');

-- --------------------------------------------------------

--
-- Struktur dari tabel `transactions`
--

CREATE TABLE `transactions` (
  `id` bigint(20) NOT NULL,
  `id_user` bigint(20) NOT NULL,
  `id_product` bigint(20) NOT NULL,
  `status` enum('unpaid','paid') NOT NULL,
  `invoice_number` varchar(20) NOT NULL,
  `date` datetime NOT NULL DEFAULT current_timestamp(),
  `payed` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Struktur dari tabel `users`
--

CREATE TABLE `users` (
  `id` bigint(20) NOT NULL,
  `name` varchar(255) NOT NULL,
  `phone` varchar(255) NOT NULL,
  `address` text NOT NULL,
  `role` enum('Admin','Buyer') NOT NULL DEFAULT 'Buyer',
  `password` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data untuk tabel `users`
--

INSERT INTO `users` (`id`, `name`, `phone`, `address`, `role`, `password`) VALUES
(1, 'Zuma Ganteng', '1234', 'Jepara', 'Admin', 'E10ADC3949BA59ABBE56E057F20F883E'),
(3, 'Nisa', '1212', 'Jogja', 'Admin', '96E79218965EB72C92A549DD5A330112');

--
-- Indexes for dumped tables
--

--
-- Indeks untuk tabel `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`id`),
  ADD KEY `created_by` (`created_by`);

--
-- Indeks untuk tabel `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_category` (`id_category`),
  ADD KEY `created_by` (`created_by`);

--
-- Indeks untuk tabel `transactions`
--
ALTER TABLE `transactions`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_user` (`id_user`),
  ADD KEY `id_product` (`id_product`);

--
-- Indeks untuk tabel `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT untuk tabel yang dibuang
--

--
-- AUTO_INCREMENT untuk tabel `categories`
--
ALTER TABLE `categories`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT untuk tabel `products`
--
ALTER TABLE `products`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- AUTO_INCREMENT untuk tabel `transactions`
--
ALTER TABLE `transactions`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT untuk tabel `users`
--
ALTER TABLE `users`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Ketidakleluasaan untuk tabel pelimpahan (Dumped Tables)
--

--
-- Ketidakleluasaan untuk tabel `categories`
--
ALTER TABLE `categories`
  ADD CONSTRAINT `categories_ibfk_1` FOREIGN KEY (`created_by`) REFERENCES `users` (`id`) ON DELETE CASCADE;

--
-- Ketidakleluasaan untuk tabel `products`
--
ALTER TABLE `products`
  ADD CONSTRAINT `products_ibfk_1` FOREIGN KEY (`id_category`) REFERENCES `categories` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `products_ibfk_2` FOREIGN KEY (`created_by`) REFERENCES `users` (`id`) ON DELETE CASCADE;

--
-- Ketidakleluasaan untuk tabel `transactions`
--
ALTER TABLE `transactions`
  ADD CONSTRAINT `transactions_ibfk_1` FOREIGN KEY (`id_user`) REFERENCES `users` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `transactions_ibfk_2` FOREIGN KEY (`id_product`) REFERENCES `products` (`id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
