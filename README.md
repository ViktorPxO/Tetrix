###Tetrix

##Што е Tetrix?
	Tetrix е комбинација на две веќе постоечки и добро познати игри: Тетрис и 2048. Интерфејсот со кој корисникот се сретува е многу едноставен. New Game копчето со кое се започнува нова игра, Pause/resume копче ја паузира играта, сивата површина каде што се одвива акцијата, три контејнери кои ги прикажуваат облиците кои следуваат, Score лабелот кој го покажува моменталниот резултат и Play 2048/Play Tetris копчето со чија помош го менуваме начинот на игра.
	 
	Со почнување на нова игра корисникот се сретнува со класичниот Тетрис. За контрола се користат четирите стрелки од тастатурата со чија помош Тетрис-парчето (tetromino) се поместува лево/десно со страничните копчиња, се ротира со притискање нагоре и се забрзува неговото паќање со притискање надолу. Со клик врз копчето Play2048 начинот на игра се менува со тоа што повеќе нема паѓачко Тетрис-парче, а оние коцкички кои се веќе паднати се однесуваат како во играта 2048. Во овој мод притискањето на копчињата ќе ги однесат сите коцки во соодветниот ќош, собирајќи ги сите соседни коцки кои имаат иста вредност. Со кликање на Play Tetris стилот на игра повторно се менува во „Тетрискиот“ со тоа што постои можноста за елиминирање на непотребните редови.
	Целта на играта е да се создаде 2048 коцкичка.

##Како работи?
	Form1.cs – главната класа која содржи променливи за резултатот, дали играта е паузирана или не, помошни променливи, референци од типот Bitmap кои ќе ги чуваат сликите кои се користат од апликацијата, неколку PictureBox референци кои подоцна се инстанцираат и со чија помош се се претставува на главниот екран, како и референца од типот tetrixGame. Класата исто така содржи и методи кои го процесираат влезот од тастатура, отчукувањето на тајмерите и кликовите на копчињата. Овие методи исто така повикуваат други соодветни методи од останатите објекти.
	#tetrixGame.cs – јадрото на играта. Оваа класа содржи регеренца кон tetrixMatrix (матрицата во позадина), activePiece (Тетрис-парчето кое е во движење), Form1 (главната класа), како и останати помошни променливи. Дел од методите во оваа класа се повикуваат на секое отчукување на тајмерот. Овие методи потоа според моменталната состојба на играта (не)повикуваат други соодветни методи. 

	tetrixMatrix.cs – класа која во себе содржи матрица од цели броеви. Кога едно Тетрис-парче нема да може повеќе да се спушта надолу вредностите од коцкичките кои тоа ги содржи се копираат во оваа матрица. Сите проверки за тоа дали еден ред е пополнет и треба да се елиминира (Тетрис) или пак две коцкички треба да се соберат (2048) се прават врз основа на вредностите во оваа матрица.

	activePiece.cs – класата која соджи референца кон Piece. При инстанцирање на објект од оваа клаца со помош на рандом број се одлучува кој ќе биде видот на тетрис-парчето.

	Piece.cs – абстракна класа која содржи низа од блокови како и методи за поместување надолу/лево/десно на тие блокови. Оваа класа исто така содржи и методи кои даваат информации за тоа дали е возможна некоја ротација/поместување на Тетрис-парчето.

	PieceI.cs
	PieceJ.cs
	PieceL.cs
	PieceO.cs
	PieceZ.cs
	PieceS.cs
	PieceT.cs
		Ова се класите кои наследуваат од Piece.cs. При инстанцирање тие ја иницијализираат листата од блокови во супер класата со тоа што локацијата на секој од блоковите е одредена според типот на тетрис-парчето. Секоја од овие класи содржи свој метод за ротација.

	Block.cs – класата која содржи Х и У координати, кои означуваат врз кој дел од матрицата моментално се наоѓа блокот односно кој од веќе постоечките PictureBox треба да се исцрта на екранот. Покрај ова класата содржи и број кој ја означува вредноста на блокот. Според оваа вредност се одлучува која слика ќе биде прикажена во соодветниот PictureBox. 

	myRandom.cs – класа која инстанцира објект од c# класата Random, а потоа одреден број од вредностите ги сместува во низа. Оваа класа постои за да може однапред да се види кој е типот на следните тетрис-парчиња.


##Детален опис на tetrixGame.cs

		
tetrixMatrix – референца кон заднинската матрица
activePiece – референца кон паѓачкото тетрис-парче
Form1 – реф. Кон главниот екран
Boolean Tetrising – булеан променлива која има вредност true кога се игра тетрис или false кога се игра 2048
Int finished – целобројна променлива која има вредност 0, освен кога играта ќе заврши. Добива вредност 1 доколку има победа или 2 доколку играчот изгубил.
Boolean goDown – булеан кој е true доколку активното парче треба да се придвижи надолу.

tetrixGame() – конструкторот на класата кој ги иницијализира rnd, bg, active, goDown, Tetrissing и finished.

void tick() – метод кој е повикан од страна на главната класа при секое отчукување на тајмерот. Доколку tetrissing е true  овој метод го повикува update() методот од оваа класа. При секое повикување на тick() тој ги повикува check2048() (проверка дали има 2048 коцкичка и дали играта е завршена) и draw() (методот за исцртување).

void checkGameOver() – метод кој проверува дали паѓачкото праче може да се спушти подолу, и доколку неможе да ја постави вредноста на finished на 2 (играта е завршена, играчот изгубил). Овој метод е повикан само при креирање на ново активно парче (activePiece).

void check2048() – објаснет погоре

void update() – метод кој доколку е возможно го поместува активното парче надолу. Доколку парчето не може да се помести надолу (веќе е стигнато до крајот) се повикува функцијата printMe() која ги копира вредностите од сите блокови во соодветната променлива од заднинската матрица. Овдека исто така се повикува и killLine() методот кој ќе уништи еден ред од заднинската матрица доколку тој е полн. (овој метод (update()) е повикан само при играње на тетрис, не кога се игра 2048)

void use2048(char where)  - метод кој е повикан од главната класа (формата) кога се игра 2048 и е притиснато копче од тастатурата. Аргументот where добива вредност ‘u’ ‘d’ ‘l’ ‘r’ (up, down, left, right) според која потоа ги поместува сите блокови од позадинската матрица во соодветната насока, собирајќи ги соседните блокови со иста вредност.

public void bringDown() – метод кој се повикува секогаш кога при играње на 2048 ќе се притисне копчето play Tetris. Овој метод сите блокови од заднинската матрица ги спушта долу (доколку се на врвот и играчот започне да игра Тетрис, ако е зафатено местото каде што треба да се појави новото активно парче играчот веднаш ќе изгуби.). единствената разлика помеѓу овој метод и use2048(‘d’) е тоа што bringDown() нема да ги собере соседните блокови со исти вредности.

int killLine() – метод кој проверува дали некој ред од заднинската матрица е пополнет. Доколку е го уништиува и спушта се што е над него за едно место надолу. Целобројната променлива што ја враќа е бројот на избришани линии при едно повикување.

Boolean checkDone() – метод кој враќа true доколку активното парче не може повече да се спушта надолу, всушност кога треба вредностите од блоковите од активното парче да се ископираат во заднинската матрица и да се создаде ново активно парче.

void printMe() – метод кој е повикан кога парчето нема да може да се движи повеќе надолу. Овој метод не прави ништо друго освен што стартува нов тајмер. За одреден период (период измерен со новиот тајмер) играчот сеуште има контрола (лево/десно) над активното парче. Во овој период парчето не паѓа надолу (нема каде). Доколку за време на овој период играчот го помести парчето над некој простор каде што нема препреки и парчето може да паѓа надолу, тоа продолжува да паѓа, а доколку ова не се случи и периодот заврши се повикува методот print().

void print() – метод кој содржината од сите блокови од активното парче ја копира во заднинската матрица, го стопира новиот тајмер (кој е стартуван во предходниот метод) и инстанцира ново активно парче (activePiece).

int getimg(int num) – метод користен од страна на draw() методот кој за влез на вредност на блок (2, 4, 8, 16, 32, 64,...) враќа која слика треба да се исцрта соодветно (1,2,3,4,5,6,...). сликите се зачувани во главната форма во низа Bitmap[] pics.

void draw() – во главната класа (Form1) имаме 10х20 матрица од PictureBox. Сите овие референци од PictureBox се инстанцирани. При цртање само менуваме некои нивни вредности, како Visible = true;,  и Image = “соодветната слика според вредноста во блокот”. Овој метод (draw) ги поминува сите блокови во активното парче и соодветните PictureBoxовие ги прикажува на екран, а потоа сите вредности од заднинската матрица и ги исцртува сите ненулеви вредности.


