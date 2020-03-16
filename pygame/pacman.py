#import all necessary modules
import pygame
import random
import os

#Set basic constant colour RGB codes
BLUE = (255,0,0)
GREEN = (0,255,0)
RED = (0,0,255)
BLACK = (0,0,0)
WHITE = (255,255,255)

#Set basic variables
Height = 577
Width = 570
FPS = 100

map =[[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0] ,
[0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0] ,
[0,1,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,1,0] ,
[0,1,0,1,1,0,1,0,1,1,1,0,1,0,0,1,0,1,1,1,0,1,0,1,1,0,1,0] ,
[0,1,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,1,0] ,
[0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0] ,
[0,1,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,1,0] ,
[0,1,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,1,0] ,
[0,1,1,1,1,1,1,0,0,1,1,1,1,0,0,1,1,1,1,0,0,1,1,1,1,1,1,0] ,
[0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0] ,
[0,1,1,1,1,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0] ,
[0,1,1,1,1,0,1,0,0,1,1,1,1,1,1,1,1,1,1,0,0,1,0,0,1,1,1,0] ,
[0,0,0,0,0,0,1,0,0,1,0,0,0,0,1,0,0,0,1,0,0,1,0,0,0,0,0,0] ,
[0,0,0,0,0,0,1,0,0,1,0,0,0,0,1,0,0,0,1,0,0,1,0,0,0,0,0,0] ,
[0,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,1,0,1,1,1,1,1,1,1,1,1,0] ,
[0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0] ,
[0,1,1,1,1,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,1,1,1,0] ,
[0,1,1,1,1,0,1,0,0,1,1,1,1,1,1,1,1,1,1,0,0,1,0,0,1,1,1,0] ,
[0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0] ,
[0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0] ,
[0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0] ,
[0,1,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,1,0] ,
[0,1,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,1,0] ,
[0,1,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,0] ,
[0,0,0,1,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,1,0,0,0] ,
[0,0,0,1,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,1,0,0,0] ,
[0,1,1,1,1,1,1,0,0,1,1,1,1,0,0,1,1,1,1,0,0,1,1,1,1,1,1,0] ,
[0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0] ,
[0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0] ,
[0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0] ,
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]]

dots_map = [[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0] ,
[0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0] ,
[0,1,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,1,0] ,
[0,1,0,1,1,0,1,0,1,1,1,0,1,0,0,1,0,1,1,1,0,1,0,1,1,0,1,0] ,
[0,1,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,1,0] ,
[0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0] ,
[0,1,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,1,0] ,
[0,1,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,1,0] ,
[0,1,1,1,1,1,1,0,0,1,1,1,1,0,0,1,1,1,1,0,0,1,1,1,1,1,1,0] ,
[0,0,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,0,0] ,
[0,1,1,1,1,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0] ,
[0,1,1,1,1,0,1,0,0,1,1,1,1,1,1,1,1,1,1,0,0,1,0,0,1,1,1,0] ,
[0,0,0,0,0,0,1,0,0,1,0,0,0,0,1,0,0,0,1,0,0,1,0,0,0,0,0,0] ,
[0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0] ,
[0,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,1,1,1,1,1,1,1,1,1,0] ,
[0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0] ,
[0,1,1,1,1,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,1,1,1,0] ,
[0,1,1,1,1,0,1,0,0,1,1,1,1,1,1,1,1,1,1,0,0,1,0,0,1,1,1,0] ,
[0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0] ,
[0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0] ,
[0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0] ,
[0,1,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,1,0] ,
[0,1,0,0,0,0,1,0,0,0,0,0,1,0,0,1,0,0,0,0,0,1,0,0,0,0,1,0] ,
[0,1,1,1,0,0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,1,1,1,0] ,
[0,0,0,1,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,1,0,0,0] ,
[0,0,0,1,0,0,1,0,0,1,0,0,0,0,0,0,0,0,1,0,0,1,0,0,1,0,0,0] ,
[0,1,1,1,1,1,1,0,0,1,1,1,1,0,0,1,1,1,1,0,0,1,1,1,1,1,1,0] ,
[0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0] ,
[0,1,0,0,0,0,0,0,0,0,0,0,1,0,0,1,0,0,0,0,0,0,0,0,0,0,1,0] ,
[0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0] ,
[0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0]]


#Initialization section
all_sprites = pygame.sprite.Group()
enemies = pygame.sprite.Group()
bullets = pygame.sprite.Group()
blocked_dots = []
pygame.init()
dots_left = 298
gate_condition = 0
last_bullet_time = pygame.time.get_ticks()
next_wave_time = pygame.time.get_ticks()
allow_next_wave = False

#Set up the folder for all the assets
asset_folder = os.path.dirname(__file__);

clock = pygame.time.Clock()
screen = pygame.display.set_mode((Width,Height))
pygame.display.set_caption('My Game')

font_name = pygame.font.match_font('arial')#To find the closest possible match to the name 'arial' 
moves = [(-1,0),(0,-1),(1,0),(0,1)]

def close_gate():
	print("Gate closed , all enemies escaped")
	global gate_condition
	global allow_next_wave
	global next_wave_time
	gate_condition = 1
	map[12][14] = 0
	next_wave_time = pygame.time.get_ticks()+30000
	allow_next_wave = True


def open_gate():
	global gate_condition
	global enclosed_enemies
	gate_condition = 0
	map[12][14] = 1
	for i in range(6) :
		enemy = Enemy()
		all_sprites.add(enemy)
		enemies.add(enemy)
	enclosed_enemies = 6



def draw_text(surf,text,size,x,y):
	font = pygame.font.Font(font_name,size)
	text_surface = font.render(text,True,BLUE)
	text_rect = text_surface.get_rect()
	text_rect.midtop = (x,y)
	surf.blit(text_surface,text_rect)

#To add explosion at the point of collision of the bullet and meteor
class Explosion(pygame.sprite.Sprite) :
	def __init__(self,position,size):
		pygame.sprite.Sprite.__init__(self)
		self.pos = position
		self.size = size
		self.image = pygame.transform.scale(explosion[0],(size,size))
		self.rect = self.image.get_rect()
		self.rect.center = position
		self.current = pygame.time.get_ticks()
		self.frame_rate = 50
		self.i = 0
		# print(self.i)
	def update(self) :
		if(pygame.time.get_ticks()-self.current>self.frame_rate) :
			self.i+=1
			# print(self.i)
			if self.i>=len(explosion) :
				self.kill()
				return
			self.current = pygame.time.get_ticks() 
			self.image = pygame.transform.scale(explosion[self.i],(self.size,self.size))
			self.rect = self.image.get_rect()
			self.rect.center = self.pos


#To add bullets to the game
class Bullets(pygame.sprite.Sprite) :
	def __init__(self,posx,posy,velox,veloy):
		pygame.sprite.Sprite.__init__(self)
		if velox==2 : 
			self.image = pygame.transform.rotate(pygame.transform.scale(laser,(10,20)),90)
		if velox==-2 : 
			self.image = pygame.transform.rotate(pygame.transform.scale(laser,(10,20)),-90)
		if veloy==2 : 
			self.image = pygame.transform.rotate(pygame.transform.scale(laser,(10,20)),0)
		if veloy==-2 : 
			self.image = pygame.transform.rotate(pygame.transform.scale(laser,(10,20)),180)
		self.rect = self.image.get_rect()
		self.count = 0
		self.rect.center = (posx,posy)
		self.velx = velox
		self.vely = veloy
	def update(self) :
		self.count += 1
		if self.count>16 :
			self.count = 0
			if map[(self.rect.centery+self.vely*10-6)/17][(self.rect.centerx+self.velx*10-8)/17]==0 :
				explo = Explosion(self.rect.center,20)
				all_sprites.add(explo)
				self.kill()
		self.rect.centery += self.vely
		self.rect.centerx += self.velx
		if self.rect.top < -20 or self.rect.left < 0 or self.rect.right > Width-100 or self.rect.bottom > Height:
			# print("ohhhhhhhhhhhhhh")
			explo = Explosion(self.rect.center,20)
			all_sprites.add(explo)
			self.kill()


class Player(pygame.sprite.Sprite):
	def __init__(self,velx,vely):
		pygame.sprite.Sprite.__init__(self)
		self.image = pygame.transform.scale(play,(25,25));
		self.x = 1
		self.y = 1
		self.velocity = (0,0)
		self.rect = self.image.get_rect()
		self.rect.center = (25,23)
		self.curr_direction = 0
		self.count = 0
		self.bullets_left = 5

	def update(self):
		self.count += 1
		global dot_left
		if(self.count>16):
			#pygame.draw.rect(screen,BLACK,self.rect)
			if(dots_map[self.y][self.x]) :
				global dots_left
				dots_left -=1
				blocked_dots.append((self.rect.centerx,self.rect.centery))
				dots_map[self.y][self.x] = 0
			self.count = 0
			self.curr_direction = direction
		if(self.curr_direction==0) :self.velocity = (0,0)
		elif(self.curr_direction==1) :
			ol_rect = self.rect
			self.image = pygame.transform.rotate(pygame.transform.scale(play,(25,25)),90)
			self.rect.center = ol_rect.center
			self.velocity = (-1,0)
		elif(self.curr_direction==2) :
			ol_rect = self.rect
			self.image = pygame.transform.rotate(pygame.transform.scale(play,(25,25)),0)
			self.rect.center = ol_rect.center
			self.velocity = (0,-1)
		elif(self.curr_direction==3) :
			ol_rect = self.rect
			self.image = pygame.transform.rotate(pygame.transform.scale(play,(25,25)),-90)
			self.rect.center = ol_rect.center
			self.velocity = (1,0)
		elif(self.curr_direction==4) :
			ol_rect = self.rect
			self.image = pygame.transform.rotate(pygame.transform.scale(play,(25,25)),180)
			self.rect.center = ol_rect.center
			self.velocity = (0,1)
		if(self.count==0):
			if (map[self.y + self.velocity[1]][self.x + self.velocity[0]]) :
				self.rect.center  = (self.rect.centerx + self.velocity[0],self.rect.centery + self.velocity[1])
				self.x += self.velocity[0]
				self.y += self.velocity[1]
			else :
				self.count = 16
		else :
			self.rect.center  = (self.rect.centerx + self.velocity[0],self.rect.centery + self.velocity[1])

class Enemy(pygame.sprite.Sprite):
	def __init__(self):
		pygame.sprite.Sprite.__init__(self)
		self.image = pygame.transform.scale(meteor,(20,20))
		self.move = moves[0]
		self.rect = self.image.get_rect()
		self.following = False
		self.x = random.randrange(11,14)
		self.y = 13
		self.rect.center = (9+17*self.x,228)
		self.count = 0
		self.velocity = (0,0)
		
	def update(self) :
		self.count += 1
		if(self.count>16):
			#Check if the enemy can see the player
			i=0
			continu = True
			follow = 0
			#Check if player is in front of the player
			while i<10 or continu :
				i+=1
				if map[self.y+i*self.move[1]][self.x+i*self.move[0]]==0 :
					break
				if self.y+i*self.move[1] == player.y and self.x+i*self.move[0] == player.x :
					follow = moves.index(self.move)+1
			
			#Check if the player is present behind the player
			continu =True
			i=0
			while i<4 or continu :
				i+=1
				if map[self.y-i*self.move[1]][self.x-i*self.move[0]]==0 :
					break
				if self.y-i*self.move[1] == player.y and self.x-i*self.move[0] == player.x :
					follow = (moves.index(self.move)+2)%4+1

			#Check if the player is present along the left or right direction of the player
			continu =True
			i=0
			while i<6 or continu :
				i+=1
				if map[self.y-i*self.move[0]][self.x-i*self.move[1]]==0 :
					break
				if self.y-i*self.move[0] == player.y and self.x-i*self.move[1] == player.x :
					follow = moves.index((-self.move[1],-self.move[0])) + 1
			continu =True
			i=0
			while i<6 or continu :
				i+=1
				if map[self.y+i*self.move[0]][self.x+i*self.move[1]]==0 :
					break
				if self.y+i*self.move[0] == player.y and self.x+i*self.move[1] == player.x :
					follow = moves.index((self.move[1],self.move[0]))+1


			if self.x==14 and self.y==12 :
				global enclosed_enemies
				enclosed_enemies -= 1
				if enclosed_enemies==0 :
					close_gate()
			self.count = 0
			if follow==0 : 
				j=-1
				possible_moves = []
				for i in moves:
					j+=1
					if map[self.y+i[1]][self.x+i[0]] and i != (-self.move[0],-self.move[1]):
						k=j
						possible_moves.append(k)
				if len(possible_moves) :
					j = random.randrange(0,len(possible_moves))
					self.move = moves[possible_moves[j]]
				else :
					self.move = (-self.move[0],-self.move[1])
				
				self.velocity = self.move
				self.x += self.move[0]
				self.y += self.move[1]
			else :
				self.move = moves[follow-1]
				self.velocity = self.move
				self.x += self.move[0]
				self.y += self.move[1]
		self.rect.x += self.velocity[0]
		self.rect.y += self.velocity[1]
		if self.rect.top>Height + 10 or self.rect.left < -30 or self.rect.right > Width + 30:
			self.rect.center = (random.randrange(Width - 30),random.randrange(-100,-40))
			
			self.velx = random.randrange(-3,3)
			self.vely = random.randrange(1,10)


#Load all game graphics
background = pygame.image.load(os.path.join(asset_folder,"pacman-map2.png"))
background = pygame.transform.scale(background,(Width,Height))
meteor = pygame.image.load(os.path.join(asset_folder,"meteorBrown_big3.png"))
laser = pygame.image.load(os.path.join(asset_folder,"laserRed16.png"))
play = pygame.image.load(os.path.join(asset_folder,"playerShip1_orange.png"))
background_rect = background.get_rect()
meteor_original = pygame.transform.scale(meteor,(50,50))
explosion = []
for i in range(9):
	filename = "regularExplosion0{}.png".format(i)
	explosion.append(pygame.image.load(os.path.join(asset_folder,filename)))

player = Player(5,5)
all_sprites.add(player)
for i in range(6) :
	enemy = Enemy()
	all_sprites.add(enemy)
	enemies.add(enemy)
enclosed_enemies = 6

# Declare necessary variables
score = 0 #To store score
prev_score = 0
color = (0,0,0)
running = True
direction = 0
run = True

while running:
	# Process input/events
	clock.tick(FPS)
	for event in pygame.event.get():
		if event.type == pygame.QUIT:
			running = False
		elif event.type == pygame.KEYDOWN:
			if event.key == pygame.K_LEFT :
				direction = 1
			if event.key == pygame.K_UP :
				direction = 2
			if event.key == pygame.K_RIGHT :
				direction = 3
			if event.key == pygame.K_DOWN :
				direction = 4
			if event.key == pygame.K_SPACE :
				if player.bullets_left>0 :
					#last_bullet_time = pygame.time.get_ticks()
					player.bullets_left -= 1
					bullet = Bullets(player.rect.centerx,player.rect.centery,2*player.velocity[0],2*player.velocity[1])
					bullets.add(bullet)
					all_sprites.add(bullet)


	# Update
	all_sprites.update() 

	
	#To detect collisions of plater with any enemy
	hits = pygame.sprite.spritecollide(player,enemies,False)
	if hits and run :
		print("You got hit by an enemy ")
		dead = pygame.time.get_ticks()
		explo = Explosion(player.rect.center,60)
		all_sprites.add(explo)
		player.kill()
		run = False
	if run == False :
		if pygame.time.get_ticks()-dead>1000 :
			running = False
	for bullet in bullets :
		hit = pygame.sprite.spritecollide(bullet,enemies,True)
		if hit : 
			bullet.kill()
			explo = Explosion(bullet.rect.center,32)
			all_sprites.add(explo)
			# print("You killed an enemy")
	
	#Check if all the dots have been consumed
	if dots_left == 0 :
		print("Hurrah!!! You have won the game")
		running = False

	#Refill the bullets in every 15 seconds
	if pygame.time.get_ticks()-last_bullet_time>15000 :
		if player.bullets_left<10 :
			player.bullets_left += 7
		last_bullet_time = pygame.time.get_ticks()

	# Set Screen
	screen.fill(color)
	screen.blit(background,background_rect)
	#print(enclosed_enemies)
	for r in blocked_dots :
		#print("yes")
		pygame.draw.rect(screen,BLACK,(r[0]-5,r[1]-5,15,15))
	if gate_condition==1 :
		pygame.draw.rect(screen,RED,(216,212,42,9))
	all_sprites.draw(screen)
	draw_text(screen,"Dots left : " + str(dots_left),28,Width/6,Height-43)
	draw_text(screen,"Bullets left : " + str(player.bullets_left),28,Width/2,Height-43)
	draw_text(screen,"Time for ",18,Width*5/6,Height-43)
	draw_text(screen,"next bullet : " + str(15 - int((pygame.time.get_ticks()-last_bullet_time)/1000)),18,Width*5/6,Height-24)
	
	#Generate new wave of enemies
	global allow_next_wave
	if allow_next_wave :
		#print("Yes")
		if pygame.time.get_ticks()>next_wave_time :
			#print("No")
			global allow_next_wave
			allow_next_wave = False
			open_gate()
		draw_text(screen,"Next wave ",18,Width-50,Height/2)
		draw_text(screen," in : " + str(int((-pygame.time.get_ticks()+next_wave_time)/1000)),18,Width-50,Height/2+20)


	# Do this at last once u r done drawing the entire thing for the frame
	pygame.display.flip()
#print("Sorry , The Game is over as you are probably hit by an enemy")

pygame.quit()
