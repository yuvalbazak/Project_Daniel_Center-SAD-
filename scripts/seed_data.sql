USE My_Daniel;
GO

-- =============================================================================
-- CLEAR (reverse FK order)
-- =============================================================================
DELETE FROM StudentsAttendanceReports;
DELETE FROM DiscountRequests;
DELETE FROM Maintenances;
DELETE FROM WorkHoursReports;
DELETE FROM Activities;
DELETE FROM Customers;
DELETE FROM Boats;
DELETE FROM ExternalCenters;
DELETE FROM Employees;
GO

-- =============================================================================
-- 1. Employees  (1 CM, 1 AM, 2 Coordinators, 6 Instructors — no Administration Staff)
-- =============================================================================
-- password = emailLocalPart + employee_id  (e.g. "ron.avivi" + "EMP001")
INSERT INTO Employees (employee_id, full_name, role, start_date, phone, email, password) VALUES
('EMP001', N'רון אביבי',      'Center Manager',    '2018-03-01', '050-1112222', 'ron.avivi@daniel-center.co.il', 'ron.aviviEMP001'),
('EMP002', N'לאה הרשקוביץ',  'Accounting Manager','2017-09-01', '052-9990001', 'lea.h@daniel-center.co.il',     'lea.hEMP002'),
('EMP003', N'תמר זיו',        'Coordinator',       '2016-06-01', '050-2223334', 'tamar.z@daniel-center.co.il',   'tamar.zEMP003'),
('EMP004', N'אלי חדד',        'Coordinator',       '2019-08-20', '052-4445556', 'eli.h@daniel-center.co.il',     'eli.hEMP004'),
('EMP005', N'נעמה טל',        'Instructor',        '2021-03-15', '054-6667778', 'naama.t@daniel-center.co.il',   'naama.tEMP005'),
('EMP006', N'גיא יצחקי',     'Instructor',        '2020-11-01', '050-8889990', 'guy.y@daniel-center.co.il',     'guy.yEMP006'),
('EMP007', N'רחל כהן',        'Instructor',        '2023-01-08', '052-0001112', 'rachel.k@daniel-center.co.il',  'rachel.kEMP007'),
('EMP008', N'דני שלום',       'Instructor',        '2022-05-15', '054-3334445', 'danny.sh@daniel-center.co.il',  'danny.shEMP008'),
('EMP009', N'אורן מזרחי',     'Instructor',        '2021-08-01', '050-5556667', 'oren.m@daniel-center.co.il',    'oren.mEMP009'),
('EMP010', N'שני אורן',       'Instructor',        '2023-03-10', '052-7778889', 'shani.o@daniel-center.co.il',   'shani.oEMP010');
GO

-- =============================================================================
-- 2. Customers  (100 rows)
--    CUST001-050 Active | CUST051-075 Unpaid | CUST076-100 Archive
-- =============================================================================
-- password column is seeded as '' here; the UPDATE below fills in emailLocalPart + customer_id
INSERT INTO Customers (customer_id, full_name, phone, email, address, birth_date, start_date, emergency_contact, payment_date, customer_status, payment_status, password) VALUES
('CUST001',N'נועה לוי',       '052-9876543','noa.levi@gmail.com',      N'הרצל 10, תל אביב',        '2012-05-20','2024-09-01','052-1111111','2024-09-01','Active','Paid',''),
('CUST002',N'אדם ברק',        '050-2223333','adam.barak@gmail.com',    N'דיזנגוף 55, תל אביב',     '2011-08-15','2024-09-01','050-4445555','2024-09-01','Active','Paid',''),
('CUST003',N'מיה שפירא',      '053-6667777','mia.shapira@gmail.com',   N'בן יהודה 22, תל אביב',    '2013-03-30','2024-09-01','053-8889999','2024-10-01','Active','Payment In Process',''),
('CUST004',N'יונתן עמר',      '054-1231234','yonatan.o@gmail.com',     N'ארלוזורוב 7, תל אביב',    '2010-11-05','2024-09-01','054-4564567','2024-09-01','Active','Paid',''),
('CUST005',N'שירה פרץ',       '050-3213211','shira.p@gmail.com',       N'רוטשילד 3, תל אביב',      '2014-02-18','2024-09-01','050-6546543','2024-09-01','Active','Paid',''),
('CUST006',N'נדב קליין',      '052-7897890','nadav.k@gmail.com',       N'אלנבי 40, תל אביב',       '2012-07-22','2024-09-01','052-0120123','2024-09-01','Active','Paid',''),
('CUST007',N'אלמה ראובן',     '054-4564560','alma.r@gmail.com',        N'שינקין 14, תל אביב',      '2011-09-10','2024-09-01','054-7897893','2024-09-01','Active','Paid',''),
('CUST008',N'ליאור שמיר',     '050-6546549','lior.sh@gmail.com',       N'נחמני 28, תל אביב',       '2012-04-03','2024-09-01','050-9879882','2024-09-01','Active','Paid',''),
('CUST009',N'דנה כהן',        '052-1122334','dana.cohen@gmail.com',    N'יהודה הלוי 5, תל אביב',  '2011-06-15','2024-09-01','052-5566778','2024-09-01','Active','Paid',''),
('CUST010',N'עמית רוזן',      '050-9988776','amit.rosen@gmail.com',    N'גורדון 18, תל אביב',      '2013-01-20','2024-09-01','050-3322110','2024-10-01','Active','Payment In Process',''),
('CUST011',N'גל אברהם',       '054-7766554','gal.avraham@gmail.com',   N'פינסקר 9, תל אביב',       '2012-09-08','2024-09-01','054-2211009','2024-09-01','Active','Paid',''),
('CUST012',N'טל בן-דוד',      '052-3344556','tal.bendavid@gmail.com',  N'מאפו 33, תל אביב',        '2010-12-12','2024-09-01','052-7788990','2024-09-01','Active','Paid',''),
('CUST013',N'רוני גרין',      '050-5544332','roni.green@gmail.com',    N'כצנלסון 12, גבעתיים',     '2011-04-25','2024-09-01','050-9988776','2024-10-01','Active','Payment In Process',''),
('CUST014',N'ענת דוד',        '054-2233445','anat.david@gmail.com',    N'ביאליק 7, רמת גן',        '2013-08-18','2024-09-01','054-6677889','2024-09-01','Active','Paid',''),
('CUST015',N'אסף הרצוג',      '052-8877665','asaf.herzlog@gmail.com',  N'עמל 22, פתח תקווה',       '2009-03-05','2023-09-01','052-3322110','2023-09-01','Active','Paid',''),
('CUST016',N'נטע ויס',        '050-1234560','neta.weis@gmail.com',     N'סוקולוב 8, חולון',        '2014-07-10','2024-09-01','050-5678904','2024-09-01','Active','Paid',''),
('CUST017',N'אורי זהבי',      '054-9876541','uri.zahavi@gmail.com',    N'ויצמן 17, בת ים',         '2012-11-30','2024-09-01','054-4321097','2024-10-01','Active','Payment In Process',''),
('CUST018',N'הילה חיימוב',    '052-6547891','hila.heim@gmail.com',     N'קוגמן 6, בת ים',          '2011-05-22','2024-09-01','052-1234567','2024-09-01','Active','Paid',''),
('CUST019',N'ייר טוביה',      '050-3216549','yair.tovia@gmail.com',    N'קרן היסוד 3, רמת השרון',  '2010-09-14','2024-09-01','050-6543212','2024-09-01','Active','Paid',''),
('CUST020',N'כרמל יוסף',      '054-7894561','carmel.yosef@gmail.com',  N'ירושלים 52, יפו',         '2013-02-28','2024-09-01','054-3214567','2024-09-01','Active','Paid',''),
('CUST021',N'לורד כץ',        '052-4567891','lord.katz@gmail.com',     N'שדרות ירושלים 11, יפו',   '2012-06-17','2024-09-01','052-8912345','2024-10-01','Active','Payment In Process',''),
('CUST022',N'מורן לוינסון',   '050-7891234','moran.lev@gmail.com',     N'שדרות אשכול 6, רמת גן',   '2011-10-09','2024-09-01','050-2345678','2024-09-01','Active','Paid',''),
('CUST023',N'נועם מרקוס',     '054-1237894','noam.marcus@gmail.com',   N'דרך השלום 29, גבעתיים',   '2010-03-23','2024-09-01','054-5671238','2024-09-01','Active','Paid',''),
('CUST024',N'אופיר נחמן',     '052-8901234','ofir.nachman@gmail.com',  N'הגליל 14, חולון',         '2013-07-07','2024-09-01','052-3456788','2024-09-01','Active','Paid',''),
('CUST025',N'פנינה סגל',      '050-2345679','penina.segal@gmail.com',  N'דרך יפו 88, תל אביב',     '2009-01-15','2023-09-01','050-6789013','2023-09-01','Active','Paid',''),
('CUST026',N'צבי עמר',        '054-3456780','zvi.amar@gmail.com',      N'הנשיא 7, רמת השרון',      '2014-04-20','2024-09-01','054-7890124','2024-09-01','Active','Paid',''),
('CUST027',N'קרן פלד',        '052-5678902','keren.peled@gmail.com',   N'הברוש 5, רמת השרון',      '2012-08-11','2024-09-01','052-9012346','2024-10-01','Active','Payment In Process',''),
('CUST028',N'ראם צדוק',       '050-4567893','raam.tzadok@gmail.com',   N'המגינים 11, בת ים',       '2011-12-03','2024-09-01','050-8901237','2024-09-01','Active','Paid',''),
('CUST029',N'שירן קפלן',      '054-6789014','shiran.kaplan@gmail.com', N'העצמאות 19, כפר סבא',     '2010-05-28','2024-09-01','054-0123458','2024-09-01','Active','Paid',''),
('CUST030',N'תום רם',         '052-7890125','tom.ram@gmail.com',       N'הירקון 70, תל אביב',      '2013-10-15','2024-09-01','052-1234569','2024-09-01','Active','Paid',''),
('CUST031',N'אביב שן',        '050-5678906','aviv.shen@gmail.com',     N'ביאליק 21, רמת גן',       '2012-03-07','2024-09-01','050-9012350','2024-10-01','Active','Payment In Process',''),
('CUST032',N'ברי תמיר',       '054-8901237','beri.tamir@gmail.com',    N'הדקל 6, רמת השרון',       '2011-07-19','2024-09-01','054-2345681','2024-09-01','Active','Paid',''),
('CUST033',N'גליה אבוטבול',   '052-0123458','galia.abut@gmail.com',    N'שינקין 8, תל אביב',       '2010-11-25','2024-09-01','052-3456792','2024-09-01','Active','Paid',''),
('CUST034',N'דביר בן-שושן',   '050-1234561','dvir.bens@gmail.com',     N'שדרות ירושלים 30, יפו',   '2009-06-13','2023-09-01','050-4567895','2023-09-01','Active','Paid',''),
('CUST035',N'הדר גביש',       '054-2345682','hadar.gavish@gmail.com',  N'הנגב 15, בת ים',          '2014-01-08','2024-09-01','054-6789126','2024-09-01','Active','Paid',''),
('CUST036',N'זיו הדס',        '052-3456793','ziv.hadas@gmail.com',     N'הירקון 44, תל אביב',      '2012-05-31','2024-09-01','052-7890237','2024-10-01','Active','Payment In Process',''),
('CUST037',N'חן ויינשטיין',   '050-6789127','chen.w@gmail.com',        N'פינסקר 24, תל אביב',      '2011-09-16','2024-09-01','050-0123461','2024-09-01','Active','Paid',''),
('CUST038',N'טובה זיגמן',     '054-9012348','tova.zigman@gmail.com',   N'רוטשילד 55, תל אביב',     '2010-02-10','2024-09-01','054-2345682','2024-09-01','Active','Paid',''),
('CUST039',N'יוסי חן',        '052-1234569','yossi.chen@gmail.com',    N'הברוש 3, רמת השרון',      '2013-06-22','2024-09-01','052-4567893','2024-09-01','Active','Paid',''),
('CUST040',N'כלנית טל',       '050-8901240','kalanit.tal@gmail.com',   N'הגיבורים 7, פתח תקווה',   '2012-10-04','2024-09-01','050-2234564','2024-10-01','Active','Payment In Process',''),
('CUST041',N'לירן יפה',       '054-0123462','liran.yafe@gmail.com',    N'יפה נוף 12, כפר סבא',     '2011-01-18','2024-09-01','054-3456796','2024-09-01','Active','Paid',''),
('CUST042',N'מעיין כהן',      '052-2345683','maayan.cohen@gmail.com',  N'ירמיהו 9, תל אביב',       '2010-08-05','2024-09-01','052-5678907','2024-09-01','Active','Paid',''),
('CUST043',N'נורית לביא',     '050-4567894','nurit.lavi@gmail.com',    N'כצנלסון 4, גבעתיים',      '2013-12-17','2024-09-01','050-7890128','2024-09-01','Active','Paid',''),
('CUST044',N'עדן מאיר',       '054-7890125','eden.meir@gmail.com',     N'אחד העם 19, תל אביב',     '2009-04-29','2023-09-01','054-1234569','2023-09-01','Active','Paid',''),
('CUST045',N'פז נוי',         '052-9012346','paz.noy@gmail.com',       N'פרישמן 44, תל אביב',      '2014-09-03','2024-09-01','052-2345680','2024-09-01','Active','Paid',''),
('CUST046',N'צליל סלע',       '050-0123462','tzlil.sela@gmail.com',    N'נחמני 12, תל אביב',       '2012-01-27','2024-09-01','050-3456796','2024-10-01','Active','Payment In Process',''),
('CUST047',N'קמיל עקירב',     '054-3456797','kamil.akrav@gmail.com',   N'הגליל 6, חולון',          '2011-05-11','2024-09-01','054-6789231','2024-09-01','Active','Paid',''),
('CUST048',N'רוי פרידמן',     '052-6789128','roy.f@gmail.com',         N'ביאליק 17, רמת גן',       '2010-09-23','2024-09-01','052-0012452','2024-09-01','Active','Paid',''),
('CUST049',N'שי צוקר',        '050-9012341','shai.zuker@gmail.com',    N'הכרמל 8, בת ים',          '2013-03-06','2024-09-01','050-2345575','2024-09-01','Active','Paid',''),
('CUST050',N'אמיר אלון',      '054-1234570','amir.alon@gmail.com',     N'הדקל 13, רמת השרון',      '2012-07-14','2024-09-01','054-4567904','2024-09-01','Active','Paid',''),
('CUST051',N'בת-אל בוחבוט',  '052-2345684','batel.b@gmail.com',       N'מרכז העיר 3, תל אביב',    '2011-02-28','2024-09-01','052-5678908','2024-09-01','Unpaid','Unpaid',''),
('CUST052',N'גדעון גולן',     '050-4567895','gideon.golan@gmail.com',  N'אחוזה 21, רמת גן',        '2010-06-16','2024-09-01','050-7890129','2024-09-01','Unpaid','Unpaid',''),
('CUST053',N'דבורה דניאל',    '054-7890126','dvora.d@gmail.com',       N'הרימון 5, יפו',           '2013-10-08','2024-09-01','054-1234560','2024-09-01','Unpaid','Unpaid',''),
('CUST054',N'האדן הלוי',      '052-9012347','haaden.h@gmail.com',      N'שדרות הנשיא 33, חולון',   '2012-02-21','2024-09-01','052-2345681','2024-09-01','Unpaid','Unpaid',''),
('CUST055',N'ויקטוריה ורטה',  '050-1234562','victoria.v@gmail.com',    N'ויצמן 6, כפר סבא',        '2014-06-14','2024-09-01','050-4567896','2024-09-01','Unpaid','Unpaid',''),
('CUST056',N'זאב זגורי',      '054-3456798','zeev.z@gmail.com',        N'הגדוד 11, גבעתיים',       '2012-10-26','2024-09-01','054-6789232','2024-09-01','Unpaid','Unpaid',''),
('CUST057',N'חיה חורי',       '052-6789129','haya.h@gmail.com',        N'המגינים 8, בת ים',        '2011-03-19','2024-09-01','052-9012353','2024-09-01','Unpaid','Unpaid',''),
('CUST058',N'טניה טרכטנברג',  '050-8901241','tania.t@gmail.com',       N'סיני 15, פתח תקווה',      '2010-07-31','2024-09-01','050-2345575','2024-09-01','Unpaid','Unpaid',''),
('CUST059',N'יוכבד יצחק',     '054-0123463','yocheved.y@gmail.com',    N'הנרייטה סאלד 4, תל אביב','2013-11-22','2024-09-01','054-3456797','2024-09-01','Unpaid','Unpaid',''),
('CUST060',N'כנרת כהן',       '052-2345685','kineret.c@gmail.com',     N'הדרים 7, רמת השרון',      '2012-04-09','2024-09-01','052-5678909','2024-09-01','Unpaid','Unpaid',''),
('CUST061',N'לירוי ליבוביץ', '050-5678907','liroy.l@gmail.com',        N'כצנלסון 3, גבעתיים',      '2011-08-01','2024-09-01','050-9012341','2024-09-01','Unpaid','Unpaid',''),
('CUST062',N'מתן מגן',        '054-8901238','matan.m@gmail.com',       N'דרך נמיר 40, תל אביב',    '2010-12-14','2024-09-01','054-2345682','2024-09-01','Unpaid','Unpaid',''),
('CUST063',N'נועה נסים',      '052-1234560','noa.nissim@gmail.com',    N'הורד 9, חולון',           '2013-05-26','2024-09-01','052-4567894','2024-09-01','Unpaid','Unpaid',''),
('CUST064',N'עמיחי עמרם',     '050-3456797','amichai.a@gmail.com',     N'שדרות ירושלים 6, יפו',    '2011-09-18','2024-09-01','050-7890231','2024-09-01','Unpaid','Unpaid',''),
('CUST065',N'פנחס פישר',      '054-6789127','pinchas.f@gmail.com',     N'ירושלים 99, יפו',         '2014-01-30','2024-09-01','054-0123461','2024-09-01','Unpaid','Unpaid',''),
('CUST066',N'צבי פלג',        '052-8901239','zvi.peleg@gmail.com',     N'בוסתן 12, רמת גן',        '2012-05-13','2024-09-01','052-2345683','2024-09-01','Unpaid','Unpaid',''),
('CUST067',N'קובי קדם',       '050-0123463','kobi.kedem@gmail.com',    N'יפה נוף 4, כפר סבא',      '2011-09-25','2024-09-01','050-3456797','2024-09-01','Unpaid','Unpaid',''),
('CUST068',N'ריבה ריינה',     '054-2345683','riva.reina@gmail.com',    N'עמיקם 16, בת ים',         '2010-02-07','2024-09-01','054-5678907','2024-09-01','Unpaid','Unpaid',''),
('CUST069',N'שמואל שינדלר',   '052-4567894','shmuel.sh@gmail.com',     N'הגיבורים 8, פתח תקווה',   '2013-06-19','2024-09-01','052-7890238','2024-09-01','Unpaid','Unpaid',''),
('CUST070',N'אלון אבני',      '050-7890129','alon.avni@gmail.com',     N'נרדמן 3, גבעתיים',        '2012-10-31','2024-09-01','050-1234563','2024-09-01','Unpaid','Unpaid',''),
('CUST071',N'בשיר בשארה',     '054-9012349','bashir.b@gmail.com',      N'שיקמה 5, יפו',            '2011-03-12','2024-09-01','054-2345683','2024-09-01','Unpaid','Payment In Process',''),
('CUST072',N'גלית גבאי',      '052-1234561','galit.g@gmail.com',       N'הגפן 7, חולון',           '2010-07-24','2024-09-01','052-4567895','2024-09-01','Unpaid','Payment In Process',''),
('CUST073',N'דורון דינשטיין', '050-3456798','doron.d@gmail.com',       N'שדרות יהודית 17, תל אביב','2013-11-05','2024-09-01','050-7890232','2024-09-01','Unpaid','Payment In Process',''),
('CUST074',N'האדי הרוש',      '054-6789128','hadi.h@gmail.com',        N'הדסה 21, יפו',            '2011-04-17','2024-09-01','054-0123462','2024-09-01','Unpaid','Payment In Process',''),
('CUST075',N'ורד וינר',       '052-8901240','vered.w@gmail.com',       N'הגלבוע 6, רמת גן',        '2014-08-29','2024-09-01','052-2345684','2024-09-01','Unpaid','Payment In Process',''),
('CUST076',N'זוהר זמיר',      '050-0123464','zohar.z@gmail.com',       N'הנגב 13, בת ים',          '2007-02-11','2022-09-01','050-3456798','2022-09-01','Archive','Paid',''),
('CUST077',N'חגית חלפון',     '054-2345684','hagit.h@gmail.com',       N'הגיבורים 4, פתח תקווה',   '2008-06-23','2022-09-01','054-5678908','2022-09-01','Archive','Paid',''),
('CUST078',N'טל טרבלסי',      '052-4567895','tal.t@gmail.com',         N'שבטי ישראל 9, גבעתיים',   '2007-10-05','2021-09-01','052-7890239','2021-09-01','Archive','Paid',''),
('CUST079',N'יצחק ירון',      '050-7890130','yitzhak.y@gmail.com',     N'ברנר 16, תל אביב',        '2008-02-17','2022-09-01','050-1234564','2022-09-01','Archive','Paid',''),
('CUST080',N'כפיר כפרי',      '054-9012350','kfir.k@gmail.com',        N'הרצוג 11, כפר סבא',       '2007-06-29','2021-09-01','054-2345684','2021-09-01','Archive','Paid',''),
('CUST081',N'לירן לוי',       '052-1234562','liran.l@gmail.com',       N'אבא הלל 6, רמת גן',       '2008-11-10','2022-09-01','052-4567896','2022-09-01','Archive','Paid',''),
('CUST082',N'מאיה מלמד',      '050-3456799','maya.m@gmail.com',        N'הגליל 8, חולון',          '2007-03-22','2021-09-01','050-7890233','2021-09-01','Archive','Paid',''),
('CUST083',N'נחמה נחמיאס',    '054-6789129','nachama.n@gmail.com',     N'הדסה 5, יפו',             '2008-07-04','2022-09-01','054-0123463','2022-09-01','Archive','Paid',''),
('CUST084',N'עינב עוז',       '052-8901241','einav.o@gmail.com',       N'הפרדס 3, בת ים',          '2007-11-16','2022-09-01','052-2345685','2022-09-01','Archive','Paid',''),
('CUST085',N'פרח פרחי',       '050-0123465','perach.p@gmail.com',      N'הגיבורים 17, פתח תקווה',  '2008-04-28','2021-09-01','050-3456799','2021-09-01','Archive','Paid',''),
('CUST086',N'צופיה צור',      '054-2345685','tzofia.t@gmail.com',      N'שדרות בגין 44, תל אביב',  '2007-09-09','2022-09-01','054-5678909','2022-09-01','Archive','Paid',''),
('CUST087',N'קריסטל קיפר',    '052-4567896','crystal.k@gmail.com',     N'כצנלסון 9, גבעתיים',      '2008-01-21','2021-09-01','052-7890240','2021-09-01','Archive','Paid',''),
('CUST088',N'רקפת ריבלין',    '050-7890131','rakefet.r@gmail.com',     N'עמנואל 6, רמת השרון',     '2007-05-03','2022-09-01','050-1234565','2022-09-01','Archive','Paid',''),
('CUST089',N'שרה שמחי',       '054-9012351','sara.s@gmail.com',        N'הסביון 14, חולון',        '2008-09-15','2022-09-01','054-2345685','2022-09-01','Archive','Paid',''),
('CUST090',N'אילן אידן',      '052-1234563','ilan.e@gmail.com',        N'השחם 3, יפו',             '2007-01-27','2021-09-01','052-4567897','2021-09-01','Archive','Paid',''),
('CUST091',N'ביאנקה ביטון',   '050-3456800','bianca.b@gmail.com',      N'ישיבת נר 5, בת ים',       '2008-05-08','2022-09-01','050-7890234','2022-09-01','Archive','Paid',''),
('CUST092',N'גב גולדשטיין',   '054-6789130','gev.g@gmail.com',         N'שדרות ירושלים 77, יפו',   '2007-09-20','2021-09-01','054-0123464','2021-09-01','Archive','Paid',''),
('CUST093',N'דניאל דיין',     '052-8901242','daniel.d@gmail.com',      N'ניסנבאום 7, תל אביב',     '2008-02-02','2022-09-01','052-2345686','2022-09-01','Archive','Paid',''),
('CUST094',N'הרצל הורביץ',    '050-0123466','herzl.h@gmail.com',       N'הלה 12, רמת גן',          '2007-06-14','2022-09-01','050-3456800','2022-09-01','Archive','Paid',''),
('CUST095',N'ורדה ורשבסקי',   '054-2345686','varda.v@gmail.com',       N'מוהליבר 4, גבעתיים',      '2008-10-26','2021-09-01','054-5678910','2021-09-01','Archive','Paid',''),
('CUST096',N'זיוה זיו',       '052-4567897','ziwa.z@gmail.com',        N'הגלגל 8, כפר סבא',        '2007-03-08','2022-09-01','052-7890241','2022-09-01','Archive','Paid',''),
('CUST097',N'חנה חנוך',       '050-7890132','hana.h@gmail.com',        N'הירקון 3, תל אביב',       '2008-07-20','2022-09-01','050-1234566','2022-09-01','Archive','Paid',''),
('CUST098',N'טוביה טוהר',     '054-9012352','tovia.t@gmail.com',       N'הגיבורים 6, פתח תקווה',   '2007-11-01','2021-09-01','054-2345686','2021-09-01','Archive','Paid',''),
('CUST099',N'יעל יהודה',      '052-1234564','yael.y@gmail.com',        N'אורות 9, חולון',          '2008-04-13','2022-09-01','052-4567898','2022-09-01','Archive','Paid',''),
('CUST100',N'אסתר אסולין',    '050-3456801','ester.a@gmail.com',       N'הדגים 5, יפו',            '2007-08-25','2022-09-01','050-7890235','2022-09-01','Archive','Paid','');
GO

-- Set customer passwords: emailLocalPart + customer_id  (e.g. "noa.levi" + "CUST001")
UPDATE Customers SET password = LEFT(email, CHARINDEX('@', email) - 1) + customer_id;
GO

-- =============================================================================
-- 3. Boats  (license-style IDs: 10xx=Kayak, 20xx=Sailing, 30xx=Academic, 90xx=External)
-- =============================================================================
-- Kayak Internal (1001-1020)
INSERT INTO Boats (boatNumber_id, boat_type, water_craft_name, boat_status, purchase_date, license_date, annual_maintenance_date, source_type) VALUES
(1001,'Kayak',N'גלי ים',      'Active',           '2020-03-10','2020-04-01','2026-04-01','Internal'),
(1002,'Kayak',N'מתז',          'Active',           '2021-06-01','2021-07-01','2026-07-01','Internal'),
(1003,'Kayak',N'שלג לבן',      'Active',           '2019-01-15','2019-02-15','2026-02-15','Internal'),
(1004,'Kayak',N'גל אדיר',      'Active',           '2022-04-10','2022-05-10','2026-05-10','Internal'),
(1005,'Kayak',N'ים כחול',      'Active',           '2020-09-01','2020-10-01','2026-10-01','Internal'),
(1006,'Kayak',N'זרם מהיר',     'Active',           '2021-11-20','2021-12-20','2026-12-20','Internal'),
(1007,'Kayak',N'משב רוח',      'Active',           '2023-02-14','2023-03-14','2027-03-14','Internal'),
(1008,'Kayak',N'קצף גלים',     'Active',           '2022-07-07','2022-08-07','2026-08-07','Internal'),
(1009,'Kayak',N'נחשול ים',     'Active',           '2020-05-18','2020-06-18','2026-06-18','Internal'),
(1010,'Kayak',N'רוח קדים',     'Active',           '2021-08-25','2021-09-25','2026-09-25','Internal'),
(1011,'Kayak',N'מי ים',        'Active',           '2023-04-03','2023-05-03','2027-05-03','Internal'),
(1012,'Kayak',N'שחף ים',       'Active',           '2022-01-11','2022-02-11','2026-02-11','Internal'),
(1013,'Kayak',N'ציפור ים',     'Active',           '2020-10-22','2020-11-22','2026-11-22','Internal'),
(1014,'Kayak',N'אופק כחול',    'Active',           '2021-03-30','2021-04-30','2026-04-30','Internal'),
(1015,'Kayak',N'לב ים',        'Active',           '2023-07-16','2023-08-16','2027-08-16','Internal'),
(1016,'Kayak',N'חוף רחוק',     'Active',           '2022-10-05','2022-11-05','2026-11-05','Internal'),
(1017,'Kayak',N'גלגל ים',      'Under Maintenance','2019-06-13','2019-07-13','2024-07-13','Internal'),
(1018,'Kayak',N'מים עמוקים',   'Under Maintenance','2020-12-01','2021-01-01','2024-01-01','Internal'),
(1019,'Kayak',N'קרח ים',       'Out Of Service',   '2017-03-20','2017-04-20','2022-04-20','Internal'),
(1020,'Kayak',N'שמיים וים',    'Out Of Service',   '2016-08-08','2016-09-08','2021-09-08','Internal');

-- Sailing Boat Internal (2001-2020)
INSERT INTO Boats (boatNumber_id, boat_type, water_craft_name, boat_status, purchase_date, license_date, annual_maintenance_date, source_type) VALUES
(2001,'Sailing Boat',N'רוח ים',      'Active',           '2018-07-01','2018-08-01','2026-08-01','Internal'),
(2002,'Sailing Boat',N'מפרש נחשול',  'Active',           '2022-04-20','2022-05-20','2026-05-20','Internal'),
(2003,'Sailing Boat',N'כוכב ים',     'Active',           '2020-02-14','2020-03-14','2026-03-14','Internal'),
(2004,'Sailing Boat',N'רוח צפונית',  'Active',           '2021-09-09','2021-10-09','2026-10-09','Internal'),
(2005,'Sailing Boat',N'ניצן מפרש',   'Active',           '2023-01-23','2023-02-23','2027-02-23','Internal'),
(2006,'Sailing Boat',N'ענן ים',      'Active',           '2019-05-17','2019-06-17','2026-06-17','Internal'),
(2007,'Sailing Boat',N'שחף לבן',     'Active',           '2022-11-11','2022-12-11','2026-12-11','Internal'),
(2008,'Sailing Boat',N'מפרש זהב',    'Active',           '2020-07-29','2020-08-29','2026-08-29','Internal'),
(2009,'Sailing Boat',N'גל עז',       'Active',           '2021-04-04','2021-05-04','2026-05-04','Internal'),
(2010,'Sailing Boat',N'בוקר כחול',   'Active',           '2023-06-18','2023-07-18','2027-07-18','Internal'),
(2011,'Sailing Boat',N'שחר ים',      'Active',           '2022-02-28','2022-03-28','2026-03-28','Internal'),
(2012,'Sailing Boat',N'כוחות טבע',   'Active',           '2019-10-06','2019-11-06','2026-11-06','Internal'),
(2013,'Sailing Boat',N'מיסטרל',      'Active',           '2021-01-15','2021-02-15','2026-02-15','Internal'),
(2014,'Sailing Boat',N'ספינת הים',   'Active',           '2020-11-22','2020-12-22','2026-12-22','Internal'),
(2015,'Sailing Boat',N'קפטן ים',     'Active',           '2023-03-07','2023-04-07','2027-04-07','Internal'),
(2016,'Sailing Boat',N'ים תיכון',    'Active',           '2022-08-19','2022-09-19','2026-09-19','Internal'),
(2017,'Sailing Boat',N'מרינה',       'Under Maintenance','2020-04-30','2020-05-30','2024-05-30','Internal'),
(2018,'Sailing Boat',N'אדריאטי',     'Under Maintenance','2019-12-12','2020-01-12','2024-01-12','Internal'),
(2019,'Sailing Boat',N'ים קלאסי',    'Out Of Service',   '2015-09-12','2015-10-12','2021-10-12','Internal'),
(2020,'Sailing Boat',N'נאבא',        'Out Of Service',   '2016-03-25','2016-04-25','2021-04-25','Internal');

-- AcademicKayak Internal (3001-3020)
INSERT INTO Boats (boatNumber_id, boat_type, water_craft_name, boat_status, purchase_date, license_date, annual_maintenance_date, source_type) VALUES
(3001,'AcademicKayak',N'קלת מים',  'Active',           '2023-02-28','2023-03-28','2027-03-28','Internal'),
(3002,'AcademicKayak',N'טורבו',    'Active',           '2022-11-01','2022-12-01','2026-12-01','Internal'),
(3003,'AcademicKayak',N'קדמה',     'Active',           '2021-05-15','2021-06-15','2026-06-15','Internal'),
(3004,'AcademicKayak',N'אחדות',    'Active',           '2020-08-20','2020-09-20','2026-09-20','Internal'),
(3005,'AcademicKayak',N'ביצועים',  'Active',           '2023-05-10','2023-06-10','2027-06-10','Internal'),
(3006,'AcademicKayak',N'מהירות',   'Active',           '2022-03-03','2022-04-03','2026-04-03','Internal'),
(3007,'AcademicKayak',N'ספרינט',   'Active',           '2021-10-19','2021-11-19','2026-11-19','Internal'),
(3008,'AcademicKayak',N'אצן',      'Active',           '2020-01-27','2020-02-27','2026-02-27','Internal'),
(3009,'AcademicKayak',N'מרתון',    'Active',           '2023-08-14','2023-09-14','2027-09-14','Internal'),
(3010,'AcademicKayak',N'פדל חזק',  'Active',           '2022-06-06','2022-07-06','2026-07-06','Internal'),
(3011,'AcademicKayak',N'כוח גלים', 'Active',           '2021-02-22','2021-03-22','2026-03-22','Internal'),
(3012,'AcademicKayak',N'זרם חזק',  'Active',           '2020-10-10','2020-11-10','2026-11-10','Internal'),
(3013,'AcademicKayak',N'עצמה',     'Active',           '2023-11-01','2023-12-01','2027-12-01','Internal'),
(3014,'AcademicKayak',N'ניצחון',   'Active',           '2022-09-17','2022-10-17','2026-10-17','Internal'),
(3015,'AcademicKayak',N'גביע זהב', 'Active',           '2021-07-05','2021-08-05','2026-08-05','Internal'),
(3016,'AcademicKayak',N'אלוף',     'Active',           '2020-04-13','2020-05-13','2026-05-13','Internal'),
(3017,'AcademicKayak',N'בשיא',     'Under Maintenance','2019-09-09','2019-10-09','2024-10-09','Internal'),
(3018,'AcademicKayak',N'תהילה',    'Under Maintenance','2018-12-24','2019-01-24','2024-01-24','Internal'),
(3019,'AcademicKayak',N'כוח ים',   'Out Of Service',   '2016-05-05','2016-06-05','2022-06-05','Internal'),
(3020,'AcademicKayak',N'ירוק גלים','Out Of Service',   '2015-11-30','2015-12-30','2021-12-30','Internal');

-- External (9001-9010)
INSERT INTO Boats (boatNumber_id, boat_type, water_craft_name, boat_status, purchase_date, license_date, annual_maintenance_date, source_type) VALUES
(9001,'Kayak',        N'ים פתוח',      'Active',           '2021-03-01','2021-04-01','2026-04-01','External'),
(9002,'Kayak',        N'גל חיצוני',    'Active',           '2022-07-15','2022-08-15','2026-08-15','External'),
(9003,'Sailing Boat', N'מפרש שאול',    'Active',           '2020-05-20','2020-06-20','2026-06-20','External'),
(9004,'Sailing Boat', N'ים שאול',      'Active',           '2021-11-10','2021-12-10','2026-12-10','External'),
(9005,'AcademicKayak',N'קיאק חיצוני', 'Active',           '2022-01-25','2022-02-25','2026-02-25','External'),
(9006,'AcademicKayak',N'שאול מרכז',   'Active',           '2023-04-12','2023-05-12','2027-05-12','External'),
(9007,'Kayak',        N'קיאק מושאל',  'Under Maintenance','2020-08-08','2020-09-08','2024-09-08','External'),
(9008,'Sailing Boat', N'ספינה שאולה', 'Out Of Service',   '2018-02-14','2018-03-14','2023-03-14','External'),
(9009,'Kayak',        N'גל שאול',      'Active',           '2021-06-30','2021-07-30','2026-07-30','External'),
(9010,'AcademicKayak',N'מושאל טורבו', 'Active',           '2022-09-03','2022-10-03','2026-10-03','External');
GO

-- =============================================================================
-- 4. ExternalCenters  (Tel Aviv / Jaffa / Herzliya only)
-- =============================================================================
INSERT INTO ExternalCenters (external_center_id, center_name, contact_name, phone) VALUES
(1, N'מרינה תל אביב',           N'ורד שמש',   '03-5431234'),
(2, N'מועדון שייט תל אביב',     N'יובל ים',   '03-6785678'),
(3, N'מרכז ספורט ימי יפו',      N'סמיר ג''אב','03-6821234'),
(4, N'אגודת ספורט ימי הרצליה',  N'ליאת גלי',  '09-9591234'),
(5, N'מרינה הרצליה',             N'גיל ים',    '09-9567890');
GO

-- =============================================================================
-- 5. Activities  (9 rows)
-- =============================================================================
INSERT INTO Activities (activityNum_id, activity_type, date_time, location, age_group) VALUES
(1,'Kayaking',       '2025-07-15 09:00:00',N'נחל הירקון - עמדה א','Youth'),
(2,'Kayaking',       '2025-07-16 09:00:00',N'נחל הירקון - עמדה א','Junior'),
(3,'Kayaking',       '2025-07-17 09:00:00',N'נחל הירקון - עמדה ב','Senior'),
(4,'Sailing',        '2025-07-15 11:00:00',N'נחל הירקון - עמדה ב','Youth'),
(5,'Sailing',        '2025-07-16 11:00:00',N'נחל הירקון - עמדה ג','Junior'),
(6,'Sailing',        '2025-07-18 11:00:00',N'נחל הירקון - עמדה ב','Elite'),
(7,'Academic Rowing','2025-07-15 14:00:00',N'נחל הירקון - עמדה א','Senior'),
(8,'Academic Rowing','2025-07-17 14:00:00',N'נחל הירקון - עמדה ג','Elite'),
(9,'Academic Rowing','2025-07-19 08:00:00',N'נחל הירקון - עמדה ב','Youth');
GO

-- =============================================================================
-- 6. DiscountRequests  (20 rows — types: Single Parent / Soldier / Employee Family / Family Package)
-- =============================================================================
INSERT INTO DiscountRequests (discount_request_Num_id, customer_id, discount_type, file_path, discount_status, discount_percent, submitted_at, resolved_at) VALUES
(1, 'CUST001','Single Parent',  NULL,                            'Pending Document Upload',NULL, '2025-06-01',NULL),
(2, 'CUST002','Soldier',        NULL,                            'Pending Document Upload',NULL, '2025-06-05',NULL),
(3, 'CUST003','Soldier',        N'/uploads/dr003_soldier.pdf',   'In Progress',            NULL, '2025-05-15',NULL),
(4, 'CUST004','Single Parent',  N'/uploads/dr004_single.pdf',    'In Progress',            NULL, '2025-05-20',NULL),
(5, 'CUST005','Family Package', N'/uploads/dr005_family.pdf',    'Approved',               15.00,'2025-04-10','2025-04-20'),
(6, 'CUST006','Employee Family',N'/uploads/dr006_empfam.pdf',    'Approved',               20.00,'2025-04-01','2025-04-12'),
(7, 'CUST007','Soldier',        N'/uploads/dr007_soldier.pdf',   'Approved',               25.00,'2024-08-01','2024-08-10'),
(8, 'CUST008','Single Parent',  N'/uploads/dr008_single.pdf',    'Declined',               NULL, '2025-03-01','2025-03-15'),
(9, 'CUST009','Family Package', N'/uploads/dr009_family.pdf',    'Declined',               NULL, '2025-05-10','2025-05-25'),
(10,'CUST010','Employee Family',N'/uploads/dr010_empfam.pdf',    'Approved',               10.00,'2024-09-01','2024-09-14'),
(11,'CUST011','Soldier',        NULL,                            'Pending Document Upload',NULL, '2025-06-10',NULL),
(12,'CUST012','Single Parent',  N'/uploads/dr012_single.pdf',    'In Progress',            NULL, '2025-05-25',NULL),
(13,'CUST013','Family Package', N'/uploads/dr013_family.pdf',    'Approved',               15.00,'2025-03-15','2025-03-28'),
(14,'CUST014','Soldier',        N'/uploads/dr014_soldier.pdf',   'Approved',               25.00,'2025-02-01','2025-02-12'),
(15,'CUST015','Employee Family',N'/uploads/dr015_empfam.pdf',    'Declined',               NULL, '2025-01-10','2025-01-25'),
(16,'CUST016','Single Parent',  N'/uploads/dr016_single.pdf',    'Approved',               20.00,'2024-10-05','2024-10-18'),
(17,'CUST017','Family Package', NULL,                            'Pending Document Upload',NULL, '2025-06-12',NULL),
(18,'CUST018','Soldier',        N'/uploads/dr018_soldier.pdf',   'In Progress',            NULL, '2025-05-30',NULL),
(19,'CUST019','Employee Family',N'/uploads/dr019_empfam.pdf',    'Approved',               10.00,'2024-11-20','2024-12-01'),
(20,'CUST020','Single Parent',  N'/uploads/dr020_single.pdf',    'Declined',               NULL, '2025-04-15','2025-04-30');
GO

-- =============================================================================
-- 7. Maintenances  (10 rows — uses new license-style boat IDs)
-- =============================================================================
INSERT INTO Maintenances (maintenance_id, boatNumber_id, reported_at, description, status, resolved_at, cost, technician_name) VALUES
(1, 1017,'2025-06-10',N'סדק בגוף הסירה — נדרש טיפול ואיטום',      'Under Maintenance',NULL,  NULL,  N'דני מכניק'),
(2, 1018,'2025-05-20',N'שבר בחרטום — הועברה לתיקון',              'Under Maintenance',NULL,  NULL,  N'יוסי נגר'),
(3, 2017,'2025-06-01',N'קרע במפרש — ממתינה לחלפים',               'Under Maintenance',NULL,  NULL,  N'דני מכניק'),
(4, 2018,'2025-04-10',N'תקלה בהגאי — ממתינה לתיקון',             'Under Maintenance',NULL,  NULL,  N'יוסי נגר'),
(5, 3017,'2025-05-15',N'שבר בחרטום הקיאק האקדמי',                 'Under Maintenance',NULL,  NULL,  N'דני מכניק'),
(6, 3018,'2025-03-20',N'נזק מבני בגוף הסירה',                     'Under Maintenance',NULL,  NULL,  N'יוסי נגר'),
(7, 1019,'2024-11-01',N'כשל מבני חמור — הוצאה משירות',            'Out Of Service',   NULL,  NULL,  N'דני מכניק'),
(8, 2019,'2024-10-15',N'נזק בלתי הפיך מסופה',                     'Out Of Service',   NULL,  NULL,  N'יוסי נגר'),
(9, 1001,'2025-04-05',N'החלפת משוט ובדיקת איטום שנתית',           'Active','2025-04-09',200.00,N'דני מכניק'),
(10,2001,'2025-03-15',N'בדיקת מפרש ותחזוקה שנתית',                'Active','2025-03-20',350.00,N'יוסי נגר');
GO

-- =============================================================================
-- 8. WorkHoursReports  (12 rows — FK → EMP003–EMP010)
-- =============================================================================
INSERT INTO WorkHoursReports (work_hours_report_num_id, employee_id, check_in, check_out, reported_hours, actual_hours, exception, is_approved, approval_note) VALUES
(1, 'EMP005','2025-06-15 08:00:00','2025-06-15 16:00:00', 8.00, 8.00, 0,1,NULL),
(2, 'EMP006','2025-06-15 08:00:00','2025-06-15 14:00:00', 6.00, 6.00, 0,1,NULL),
(3, 'EMP007','2025-06-15 09:00:00','2025-06-15 17:00:00', 8.00, 8.00, 0,1,NULL),
(4, 'EMP003','2025-06-15 07:00:00','2025-06-15 18:00:00',11.00,11.00, 0,1,NULL),
(5, 'EMP004','2025-06-15 07:30:00','2025-06-15 19:00:00',11.50,11.50, 0,1,NULL),
(6, 'EMP008','2025-06-15 09:00:00','2025-06-15 17:00:00', 8.00, 8.00, 0,1,NULL),
(7, 'EMP005','2025-06-16 08:00:00','2025-06-16 16:00:00', 9.50, 8.00, 1,1,N'אושר — הפרש עקב תרגיל מילואים'),
(8, 'EMP006','2025-06-16 08:00:00','2025-06-16 14:00:00', 6.00, 6.00, 0,1,NULL),
(9, 'EMP009','2025-06-16 09:00:00','2025-06-16 17:00:00', 0.00, 8.00, 1,0,NULL),
(10,'EMP003','2025-06-16 07:00:00','2025-06-16 19:00:00',14.00,11.00, 1,1,N'אושר — שעות נוספות עקב אירוע מיוחד'),
(11,'EMP010','2025-06-17 08:00:00','2025-06-17 16:00:00', 8.00, 8.00, 0,0,NULL),
(12,'EMP007','2025-06-17 08:00:00','2025-06-17 14:00:00', 6.00, 6.00, 0,0,NULL);
GO

-- =============================================================================
-- 9. StudentsAttendanceReports  (63 rows = 7 per activity × 9 activities)
-- =============================================================================
INSERT INTO StudentsAttendanceReports (attendance_report_id, activityNum_id, customer_id, attendance_status, notes) VALUES
(1, 1,'CUST001','Present',               NULL),
(2, 1,'CUST002','Present',               NULL),
(3, 1,'CUST003','Present',               NULL),
(4, 1,'CUST004','Present',               NULL),
(5, 1,'CUST005','Present',               NULL),
(6, 1,'CUST006','Absent With Notice',    N'מחלה'),
(7, 1,'CUST007','Absent Without Notice', NULL),
(8, 2,'CUST008','Present',               NULL),
(9, 2,'CUST009','Present',               NULL),
(10,2,'CUST010','Present',               NULL),
(11,2,'CUST011','Present',               NULL),
(12,2,'CUST012','Present',               NULL),
(13,2,'CUST013','Absent With Notice',    N'טיול בית ספר'),
(14,2,'CUST014','Absent Without Notice', NULL),
(15,3,'CUST015','Present',               NULL),
(16,3,'CUST016','Present',               NULL),
(17,3,'CUST017','Present',               NULL),
(18,3,'CUST018','Present',               NULL),
(19,3,'CUST019','Present',               NULL),
(20,3,'CUST020','Absent With Notice',    N'אירוע ספורט לאומי'),
(21,3,'CUST021','Absent Without Notice', NULL),
(22,4,'CUST022','Present',               NULL),
(23,4,'CUST023','Present',               NULL),
(24,4,'CUST024','Present',               NULL),
(25,4,'CUST025','Present',               NULL),
(26,4,'CUST026','Present',               NULL),
(27,4,'CUST027','Absent With Notice',    N'פגישה רפואית'),
(28,4,'CUST028','Absent Without Notice', NULL),
(29,5,'CUST029','Present',               NULL),
(30,5,'CUST030','Present',               NULL),
(31,5,'CUST031','Present',               NULL),
(32,5,'CUST032','Present',               NULL),
(33,5,'CUST033','Present',               NULL),
(34,5,'CUST034','Absent With Notice',    N'פגישה רפואית'),
(35,5,'CUST035','Absent Without Notice', NULL),
(36,6,'CUST036','Present',               NULL),
(37,6,'CUST037','Present',               NULL),
(38,6,'CUST038','Present',               NULL),
(39,6,'CUST039','Present',               NULL),
(40,6,'CUST040','Present',               NULL),
(41,6,'CUST041','Absent With Notice',    N'תחרות אזורית'),
(42,6,'CUST042','Absent Without Notice', NULL),
(43,7,'CUST043','Present',               NULL),
(44,7,'CUST044','Present',               NULL),
(45,7,'CUST045','Present',               NULL),
(46,7,'CUST046','Present',               NULL),
(47,7,'CUST047','Present',               NULL),
(48,7,'CUST048','Absent With Notice',    N'חופשה משפחתית'),
(49,7,'CUST049','Absent Without Notice', NULL),
(50,8,'CUST050','Present',               NULL),
(51,8,'CUST051','Present',               NULL),
(52,8,'CUST052','Present',               NULL),
(53,8,'CUST053','Present',               NULL),
(54,8,'CUST054','Present',               NULL),
(55,8,'CUST055','Absent With Notice',    N'אירוע בית ספרי'),
(56,8,'CUST056','Absent Without Notice', NULL),
(57,9,'CUST057','Present',               NULL),
(58,9,'CUST058','Present',               NULL),
(59,9,'CUST059','Present',               NULL),
(60,9,'CUST060','Present',               NULL),
(61,9,'CUST061','Present',               NULL),
(62,9,'CUST062','Absent With Notice',    N'מחלה'),
(63,9,'CUST063','Absent Without Notice', NULL);
GO

