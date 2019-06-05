DROP DATABASE PhoneDirectory;
CREATE DATABASE PhoneDirectory;
USE PhoneDirectory;


CREATE TABLE directory (
  Id INT NOT NULL,
  Name VARCHAR(100) NOT NULL,
  Nickname VARCHAR(100) NOT NULL,
  PhoneNumber VARCHAR(100) NOT NULL,
  MobileNumber VARCHAR(100) NOT NULL,
  EmailAddress VARCHAR(100) NOT NULL,
  HomeAddress VARCHAR(100) NOT NULL,
  Company VARCHAR(100) NOT NULL,
  Position VARCHAR(100) NOT NULL,
  GroupName VARCHAR(100) NOT NULL,
  Website VARCHAR(100) NOT NULL,
  FacebookAccount VARCHAR(100) NOT NULL,
  Remarks VARCHAR(100) NOT NULL
)

ALTER TABLE directory ADD PRIMARY KEY (Id);
 
INSERT INTO directory (Id, Name,                 Nickname,      PhoneNumber,   MobileNumber, EmailAddress,                 HomeAddress,   Company,          Position,       GroupName,    Website,                    FacebookAccount,  Remarks) 
               VALUES
					(1,   'Asegid belew',       'reta',        '224-1234',    '09486013158', '',                           '',           'Gordon College', 'Student',      'Family',    'www.w3school.com',          '',              'Deleted'),
					(2,   'Mulualem Gelaw',     'merek',       '224-4321',    '09194298959', 'mulerwello@gmail.com',       '',           'Gordon College', 'Student',      'Family',    'www.ubuntu.com',            '',              ''),
					(3,   'Fentaw Hailu',       'kewus',       '2248-154',    '09279816975', 'fentaw.hailu@gmail.com.com', '',           'Gordon College', 'Student',      'Family',    'www.stackoverflow.com',     '',              ''),
					(4,   'Frezer Yirga',       'Awtulgn',     '224-1211',    '09995463721', 'frazieryirka@gmail.com',     '',           'Gordon College', 'Student',      'Classmate', 'www.godaddy.com',           '',              ''),
					(5,   'Ntsuh Sme',          'ntsi',        '556-777-009', '09498528089', '',                           '',           'MWSI',           'Board Leader', 'Student',   'www.thehiddenwiki.com',     '',              ''),
					(6,   'Minilik Demle',      'M',           '777-008-666', '09638838384', '',                           '',           'MWSI',           'Board Leader', 'Student',   'www.torproject.org',        '',              ''),
					(7,   'Mandefro Weret',     'manda',       '888-543-123', '09123456782', '',                           '',           'RTW',            'Manager',      'Classmate', 'www.wikihow.com',           '',              ''),
					(8,   'Yaregal Bante',      'kewus2',      '123-345-897', '09563893782', '',                           '',           'RTW',            'President',    'Family',    'www.wikileaks.com',         '',              ''),
					(9,   'Abdu Gerema',        'Ebdu',        '556-577-444', '09364633738', '',                           '',           'MWSI',           'Manager',      'Family',    'www.thehackersnews.com',    '',              ''),
					(10,  'Milion Desalegn',    'serifam',     '556-444-890', '09343434343', '',                           '',           'MC',             'Teacher',      'Family',    'www.hackersonlineclub.com', '',              ''),
					(11,  'Mikiyas Eshetu',     'tlanian',     '122-898-566', '09987653321', '',                           '',           'MWSI',           'Manager',      'Family',    'www.github.com',            '',              ''),
					(12,  'Abdulaziz Ahmed',    'knche',       '030-777-778', '09345633461', '',                           '',           'RTW',            'Manager',      'Student',   'www.softonic.com',          '',              ''),
					(13,  'Usman Seid',         'capitain',    '568-333-999', '09373773733', '',                           '',           'RTW',            'Manager',      'Family',    'www.bluehost.com',          '',              ''),
					(14,  'Adem Kebede',        'alex',        '888-544-098', '09303030494', '',                           '',           'MWSI',           'Teacher',      'Classmate', 'www.digitalocean.com',      '',              ''),
					(15,  'Alemayehu Mulugeta', 'Kiko',        '743-344-466', '09236464747', '',                           '',           'RTW',            'Manager',      'Family',    'www.archlinux.org',         '',              ''),
					(16,  'Eden Alive',         'edu',         '443-775-544', '09373222227', '',                           '',           'MWSI',           'President',    'Family',    'www.wordpress.com',         '',              ''),
					(17,  'Heaven Here',        'hevi',        '003-344-005', '09444449223', '',                           '',           'RTW',            'President',    'Classmate', 'www.quircky.com',           '',              ''),
					(19,  'Markan Markon',      'mar',         '000-000-000', '32904823906', '',                           '',           'KKK',            'President',    'Classmate', 'www.yenepay.com',           '',              '');


