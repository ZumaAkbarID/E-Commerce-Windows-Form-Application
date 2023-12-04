-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 04, 2023 at 05:19 PM
-- Server version: 10.4.28-MariaDB
-- PHP Version: 8.2.4

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
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `id` bigint(20) NOT NULL,
  `created_by` bigint(20) NOT NULL,
  `category_name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`id`, `created_by`, `category_name`) VALUES
(1, 1, 'Food'),
(2, 1, 'Beverage'),
(3, 1, 'Handphone'),
(13, 1, 'Laptop'),
(14, 1, 'Powerbank');

-- --------------------------------------------------------

--
-- Table structure for table `products`
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
-- Dumping data for table `products`
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
(14, 1, 1, 'Spaghetti', 'Pasta spaghetti with grilled shrimps bechamel sauce. Spaghetti with seafood rich cream. Cooking mediterranean food with savory prawns, macro top view, blue table, italian cuisine, vertical', 123, 39900, 'https://i.ibb.co/YXpM21p/image.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `transactions`
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

--
-- Dumping data for table `transactions`
--

INSERT INTO `transactions` (`id`, `id_user`, `id_product`, `status`, `invoice_number`, `date`, `payed`) VALUES
(1, 1, 7, 'unpaid', 'INV-1AKWH3', '2023-12-01 16:47:17', NULL),
(2, 1, 7, 'unpaid', 'INV-JXQVMN', '2023-12-01 17:10:17', NULL),
(3, 1, 7, 'unpaid', 'INV-QY5JPL', '2023-12-01 17:14:20', NULL),
(4, 1, 7, 'unpaid', 'INV-DBYVR1', '2023-12-01 17:18:03', NULL),
(5, 1, 7, 'paid', 'INV-ICINXH', '2023-12-01 17:20:39', 123233),
(6, 1, 10, 'paid', 'INV-8HC1BZ', '2023-12-02 07:50:33', 1200000),
(7, 3, 11, 'paid', 'INV-2G81SK', '2023-12-04 06:47:39', 15000000),
(8, 3, 5, 'paid', 'INV-9XQNOC', '2023-12-04 07:14:10', 150000),
(9, 3, 10, 'unpaid', 'INV-IMY9MZ', '2023-12-04 10:50:59', NULL),
(10, 3, 10, 'unpaid', 'INV-ZA9KSW', '2023-12-04 10:51:00', NULL),
(11, 3, 10, 'unpaid', 'INV-MSIJXR', '2023-12-04 10:52:26', NULL),
(12, 3, 10, 'unpaid', 'INV-ZTVKZ6', '2023-12-04 10:52:27', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `users`
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
-- Dumping data for table `users`
--

INSERT INTO `users` (`id`, `name`, `phone`, `address`, `role`, `password`) VALUES
(1, 'Zuma Ganteng', '1234', 'Jepara', 'Admin', 'E10ADC3949BA59ABBE56E057F20F883E'),
(2, 'asdasd', '1221', 'asdasdasd', 'Buyer', 'E10ADC3949BA59ABBE56E057F20F883E'),
(3, 'Nisa', '1212', 'Jogja', 'Buyer', '96E79218965EB72C92A549DD5A330112');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`id`),
  ADD KEY `created_by` (`created_by`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_category` (`id_category`),
  ADD KEY `created_by` (`created_by`);

--
-- Indexes for table `transactions`
--
ALTER TABLE `transactions`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id_user` (`id_user`),
  ADD KEY `id_product` (`id_product`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT for table `transactions`
--
ALTER TABLE `transactions`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `id` bigint(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `categories`
--
ALTER TABLE `categories`
  ADD CONSTRAINT `categories_ibfk_1` FOREIGN KEY (`created_by`) REFERENCES `users` (`id`) ON DELETE CASCADE;

--
-- Constraints for table `products`
--
ALTER TABLE `products`
  ADD CONSTRAINT `products_ibfk_1` FOREIGN KEY (`id_category`) REFERENCES `categories` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `products_ibfk_2` FOREIGN KEY (`created_by`) REFERENCES `users` (`id`) ON DELETE CASCADE;

--
-- Constraints for table `transactions`
--
ALTER TABLE `transactions`
  ADD CONSTRAINT `transactions_ibfk_1` FOREIGN KEY (`id_user`) REFERENCES `users` (`id`) ON DELETE CASCADE,
  ADD CONSTRAINT `transactions_ibfk_2` FOREIGN KEY (`id_product`) REFERENCES `products` (`id`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
