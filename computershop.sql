-- phpMyAdmin SQL Dump
-- version 4.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Oct 25, 2017 at 10:51 PM
-- Server version: 10.1.16-MariaDB
-- PHP Version: 5.6.24

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `computershop`
--

-- --------------------------------------------------------

--
-- Table structure for table `tbl_admin`
--

CREATE TABLE `tbl_admin` (
  `username` varchar(100) NOT NULL,
  `password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_item_brand`
--

CREATE TABLE `tbl_item_brand` (
  `brand` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_item_brand`
--

INSERT INTO `tbl_item_brand` (`brand`) VALUES
('Kingston'),
('CD-R King'),
('Cruzer Blade');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_item_color`
--

CREATE TABLE `tbl_item_color` (
  `color` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_item_color`
--

INSERT INTO `tbl_item_color` (`color`) VALUES
('Black'),
('Red'),
('White'),
('Green');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_item_supplier`
--

CREATE TABLE `tbl_item_supplier` (
  `supplier` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `tbl_item_supplier`
--

INSERT INTO `tbl_item_supplier` (`supplier`) VALUES
('Electronics'),
('Octagon'),
('Silicon Valley'),
('Data World');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_sales`
--

CREATE TABLE `tbl_sales` (
  `transaction_no` varchar(500) NOT NULL,
  `product_id` varchar(100) NOT NULL,
  `item` varchar(100) NOT NULL,
  `brand` varchar(100) NOT NULL,
  `size` varchar(100) NOT NULL,
  `byte` varchar(100) NOT NULL,
  `capacity` varchar(100) NOT NULL,
  `color` varchar(100) NOT NULL,
  `supplier` varchar(100) NOT NULL,
  `arrival_date` varchar(100) NOT NULL,
  `unit_price` decimal(65,2) NOT NULL,
  `selling_price` decimal(65,2) NOT NULL,
  `quantity` int(100) NOT NULL,
  `total_price` decimal(65,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_stocks`
--

CREATE TABLE `tbl_stocks` (
  `product_id` varchar(100) NOT NULL,
  `item` varchar(100) NOT NULL,
  `brand` varchar(100) NOT NULL,
  `size` varchar(100) NOT NULL,
  `byte` varchar(500) NOT NULL,
  `capacity` varchar(100) NOT NULL,
  `color` varchar(100) NOT NULL,
  `supplier` varchar(100) NOT NULL,
  `arrival_date` varchar(100) NOT NULL,
  `unit_price` decimal(65,2) NOT NULL,
  `quantity` int(100) NOT NULL,
  `total_price` decimal(65,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `tbl_transactions`
--

CREATE TABLE `tbl_transactions` (
  `transaction_no` varchar(300) NOT NULL,
  `transaction_date` varchar(300) NOT NULL,
  `client` varchar(300) NOT NULL,
  `address` varchar(300) NOT NULL,
  `contact_number` varchar(300) NOT NULL,
  `total_quantity` varchar(100) NOT NULL,
  `cash` decimal(65,2) NOT NULL,
  `change` decimal(65,2) NOT NULL,
  `total_payment` decimal(65,2) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
