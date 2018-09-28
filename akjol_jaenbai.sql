-- phpMyAdmin SQL Dump
-- version 4.6.5.2
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: Sep 29, 2018 at 12:08 AM
-- Server version: 5.6.35
-- PHP Version: 7.0.15

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `akjol_jaenbai`
--
CREATE DATABASE IF NOT EXISTS `akjol_jaenbai` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci;
USE `akjol_jaenbai`;

-- --------------------------------------------------------

--
-- Table structure for table `clients`
--

CREATE TABLE `clients` (
  `id` int(11) NOT NULL,
  `clientName` varchar(255) NOT NULL,
  `stylist_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `clients`
--

INSERT INTO `clients` (`id`, `clientName`, `stylist_id`) VALUES
(1, 'ilgiz', 5),
(3, 'Michael Jackson', 5),
(4, 'elvis presley', 6),
(5, 'elvis presley', 5),
(6, 'santa', 5),
(7, 'jon jones', 1),
(8, 'person', 2),
(9, 'person1', 3),
(10, 'asd', 3),
(11, 'jon jones', 1),
(12, 'person3', 2),
(13, 'Michael Jackson', 3),
(14, 'Justin Bieber', 3);

-- --------------------------------------------------------

--
-- Table structure for table `specialties`
--

CREATE TABLE `specialties` (
  `id` int(11) NOT NULL,
  `description` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

--
-- Dumping data for table `specialties`
--

INSERT INTO `specialties` (`id`, `description`) VALUES
(1, 'Hairwash'),
(2, 'Hairwash'),
(3, 'Hairwash'),
(4, 'Hairwash'),
(5, 'Hairwash'),
(6, 'Hairwash'),
(7, 'Hairwash'),
(8, 'Hairwash'),
(9, 'Hairwash'),
(10, 'Hairwash'),
(11, 'Cleaning'),
(12, 'Cleaning'),
(13, 'Cleaning'),
(14, 'BodyWash'),
(15, 'DishWasher'),
(16, 'HairDryer'),
(17, 'HairCutter');

-- --------------------------------------------------------

--
-- Table structure for table `stylists`
--

CREATE TABLE `stylists` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `stylists`
--

INSERT INTO `stylists` (`id`, `name`) VALUES
(3, 'AJ SuperGoodHairStylist'),
(5, 'Aj BestHairCutter'),
(6, 'AJ SuperGoodHairStylist'),
(7, 'Ted Gibson'),
(8, 'Ted Gibson'),
(9, 'Ted Gibson'),
(10, 'VW'),
(11, 'VW'),
(12, 'VW'),
(13, 'Krylov'),
(14, 'VW'),
(15, 'Einstein');

-- --------------------------------------------------------

--
-- Table structure for table `stylists_specialties`
--

CREATE TABLE `stylists_specialties` (
  `id` int(11) NOT NULL,
  `stylist_id` int(11) NOT NULL,
  `specialty_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=COMPACT;

--
-- Dumping data for table `stylists_specialties`
--

INSERT INTO `stylists_specialties` (`id`, `stylist_id`, `specialty_id`) VALUES
(1, 0, 12),
(2, 0, 13),
(3, 0, 14),
(4, 1, 15),
(5, 5, 16),
(6, 7, 17),
(7, 12, 1),
(8, 13, 16),
(9, 14, 17),
(10, 15, 1),
(11, 14, 15),
(12, 1, 16),
(13, 5, 1),
(14, 1, 1),
(15, 1, 1),
(16, 1, 1),
(17, 1, 1),
(18, 1, 1),
(19, 1, 1),
(20, 1, 15),
(21, 4, 1),
(22, 4, 14),
(23, 3, 14),
(24, 3, 16),
(25, 10, 16),
(26, 10, 14);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `clients`
--
ALTER TABLE `clients`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `specialties`
--
ALTER TABLE `specialties`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylists`
--
ALTER TABLE `stylists`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `stylists_specialties`
--
ALTER TABLE `stylists_specialties`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `clients`
--
ALTER TABLE `clients`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;
--
-- AUTO_INCREMENT for table `specialties`
--
ALTER TABLE `specialties`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;
--
-- AUTO_INCREMENT for table `stylists`
--
ALTER TABLE `stylists`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;
--
-- AUTO_INCREMENT for table `stylists_specialties`
--
ALTER TABLE `stylists_specialties`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=27;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
