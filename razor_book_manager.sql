-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th9 25, 2024 lúc 07:19 PM
-- Phiên bản máy phục vụ: 10.4.32-MariaDB
-- Phiên bản PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `razor_book_manager`
--
CREATE DATABASE IF NOT EXISTS `razor_book_manager` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE `razor_book_manager`;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `booksales`
--

CREATE TABLE `booksales` (
  `id` int(11) NOT NULL,
  `title` varchar(50) NOT NULL,
  `quantity` int(11) NOT NULL,
  `price` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Đang đổ dữ liệu cho bảng `booksales`
--

INSERT INTO `booksales` (`id`, `title`, `quantity`, `price`) VALUES
(1, 'Đường Hầm Mùa Hạ Tập 1', 1000, 120000),
(2, 'Đường Hầm Mùa Hạ Tập 2', 1500, 120000),
(3, 'Đường Hầm Mùa Hạ Tập 3', 500, 120000),
(4, 'Đường Hầm Mùa Hạ Tập 4', 2000, 120000),
(5, 'Đường Hầm Mùa Hạ Tập 5', 1000, 120000),
(6, 'Đường Hầm Mùa Hạ Tập 6', 1500, 120000),
(7, 'Đường Hầm Mùa Hạ Tập 7', 500, 120000),
(8, 'Đường Hầm Mùa Hạ Tập 8', 2000, 120000),
(9, 'Đường Hầm Mùa Hạ Tập 9', 1000, 120000),
(10, 'Đường Hầm Mùa Hạ Tập 10', 1500, 120000),
(11, 'Dế Mèo Phiêu Lưu Ký Tập 1', 500, 130000),
(12, 'Dế Mèo Phiêu Lưu Ký Tập 2', 1000, 130000),
(13, 'Dế Mèo Phiêu Lưu Ký Tập 3', 1500, 130000),
(14, 'Dế Mèo Phiêu Lưu Ký Tập 4', 2000, 130000),
(15, 'Dế Mèo Phiêu Lưu Ký Tập 5', 500, 130000),
(16, 'Dế Mèo Phiêu Lưu Ký Tập 6', 1000, 130000),
(17, 'Dế Mèo Phiêu Lưu Ký Tập 7', 1500, 130000),
(18, 'Dế Mèo Phiêu Lưu Ký Tập 8', 2000, 130000),
(19, 'Dế Mèo Phiêu Lưu Ký Tập 9', 500, 130000),
(20, 'Dế Mèo Phiêu Lưu Ký Tập 10', 1000, 130000),
(21, 'Hành Trình Đến Bắc Cực Tập 1', 1500, 140000),
(22, 'Hành Trình Đến Bắc Cực Tập 2', 2000, 140000),
(23, 'Hành Trình Đến Bắc Cực Tập 3', 500, 140000),
(24, 'Hành Trình Đến Bắc Cực Tập 4', 1000, 140000),
(25, 'Hành Trình Đến Bắc Cực Tập 5', 1500, 140000),
(26, 'Hành Trình Đến Bắc Cực Tập 6', 2000, 140000),
(27, 'Hành Trình Đến Bắc Cực Tập 7', 500, 140000),
(28, 'Hành Trình Đến Bắc Cực Tập 8', 1000, 140000),
(29, 'Hành Trình Đến Bắc Cực Tập 9', 1500, 140000),
(30, 'Hành Trình Đến Bắc Cực Tập 10', 2000, 140000),
(31, 'Bỗng Dưng Muốn Khóc Tập 1', 1000, 110000),
(32, 'Bỗng Dưng Muốn Khóc Tập 2', 1500, 110000),
(33, 'Bỗng Dưng Muốn Khóc Tập 3', 500, 110000),
(34, 'Bỗng Dưng Muốn Khóc Tập 4', 2000, 110000),
(35, 'Bỗng Dưng Muốn Khóc Tập 5', 1000, 110000),
(36, 'Bỗng Dưng Muốn Khóc Tập 6', 1500, 110000),
(37, 'Bỗng Dưng Muốn Khóc Tập 7', 500, 110000),
(38, 'Bỗng Dưng Muốn Khóc Tập 8', 2000, 110000),
(39, 'Bỗng Dưng Muốn Khóc Tập 9', 1000, 110000),
(40, 'Bỗng Dưng Muốn Khóc Tập 10', 1500, 110000),
(41, 'Tên Của Bạn Là Tập 1', 500, 150000),
(42, 'Tên Của Bạn Là Tập 2', 1000, 150000),
(43, 'Tên Của Bạn Là Tập 3', 1500, 150000),
(44, 'Tên Của Bạn Là Tập 4', 2000, 150000),
(45, 'Tên Của Bạn Là Tập 5', 500, 150000),
(46, 'Tên Của Bạn Là Tập 6', 1000, 150000),
(47, 'Tên Của Bạn Là Tập 7', 1500, 150000),
(48, 'Tên Của Bạn Là Tập 8', 2000, 150000),
(49, 'Tên Của Bạn Là Tập 9', 500, 150000),
(50, 'Tên Của Bạn Là Tập 10', 1000, 150000);

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `booksales`
--
ALTER TABLE `booksales`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `title` (`title`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `booksales`
--
ALTER TABLE `booksales`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=51;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
