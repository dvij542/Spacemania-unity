import pygame 
import random
import math
from os import path


WIDTH=1700
HEIGHT=1000
FPS=60
GRAVITY=0.1


WHITE=(255,255,255)
BLACK=(0,0,0)


pygame.init()
screen=pygame.display.set_mode((WIDTH,HEIGHT))
pygame.display.set_caption("Game")
clock=pygame.time.Clock()
arrow_img=pygame.image.load(path.join(path.dirname(__file__),"arrow.png")).convert()
last_bullet_time = pygame.time.get_ticks()

def Check_Arrows(arrows) :
	for arrow in arrows :
		if arrow.Released :
			continue
		else :
			return False
	return True		

class Arrow(pygame.sprite.Sprite) :
	def __init__(self):
		pygame.sprite.Sprite.__init__(self)
		# self.image_orig = pygame.Surface((5,50))
		# self.image_orig.fill(BLACK)
		self.image_orig=arrow_img
		self.image=self.image_orig
		self.rect=self.image.get_rect()
		self.rect.centerx= WIDTH/2
		self.rect.bottom= HEIGHT- 20
		self.rot=0
		self.speedx=0
		self.speedy=0
		self.range=0
		self.max_height=0
		self.release_angle=0
		self.set_vel= False
		self.Released=False
		self.releasex=self.rect.centerx
		self.releasey=self.rect.bottom
		self.cy = self.rect.centery 

	def update(self):
		if self.Released :
			self.speedy-=GRAVITY
			self.rect.bottom-=self.speedy
			self.rect.centerx+=self.speedx
			self.rot=(-math.atan2(self.speedx,self.speedy)*180/3.14)%360
			new_image=pygame.transform.rotate(self.image_orig,self.rot)
			old_center=self.rect.center
			self.image=new_image
			self.rect=self.image.get_rect()
			self.rect.center=old_center
			print "moving"


		else :
			mouse =pygame.mouse.get_pos()
			click =pygame.mouse.get_pressed()
			if click[0]==1 :
				self.set_vel = True
				dist=math.sqrt(math.pow(self.rect.centerx-mouse[0],2)+math.pow(self.rect.bottom-mouse[1],2))
				print dist
				#if dist<50 :
				self.rect.centerx =mouse[0]
				self.rect.centery=mouse[1]
				print(2*GRAVITY*(self.rect.centery-mouse[1]))
				self.speedy=math.sqrt(2*GRAVITY*(-self.cy+mouse[1]))*4
				self.speedx=self.speedy * (mouse[0]-self.releasex)/(self.cy-mouse[1])
				self.rot=(-math.atan2(self.speedx,self.speedy)*180/3.14)%360
				new_image=pygame.transform.rotate(self.image_orig,self.rot)
				old_center=self.rect.center
				self.image=new_image
				self.rect=self.image.get_rect()
				self.rect.center=old_center
				#self.rect.centerx=self.releasex
				#self.rect.bottom=self.releasey
				print "setting velocity"

			else :
				if self.set_vel :
					self.Released = True
					self.max_height= (self.rect.bottom-mouse[1])
					self.range=(mouse[0]-self.rect.centerx)*2
					print "releasing"
				else :
					if (mouse[0]-self.rect.centerx) != 0 :
						theta=math.atan((mouse[1]-self.rect.bottom)/(self.rect.centerx-mouse[0]))
					else :
						theta= 3.14
					move=theta-self.rot	
					self.rot+=theta
					new_image=pygame.transform.rotate(self.image_orig,self.rot)
					old_center=self.rect.center
					self.image=new_image
					self.rect=self.image.get_rect()
					self.rect.center=old_center
					print "rotating"
					print self.rot
					print theta 	



all_sprites= pygame.sprite.Group()
arrows=[]
count=0
new_arrow=Arrow()
all_sprites.add(new_arrow)

while True :
	clock.tick(FPS)
	for event in pygame.event.get():
		if event.type == pygame.QUIT :
			running = False


	#if Check_Arrows(arrows):
	#	new_arrow=Arrow()
	#	all_sprites.add(new_arrow)
	#	count+=1
		
	print count		

	all_sprites.update()
	
	screen.fill(WHITE)
	all_sprites.draw(screen)
	pygame.display.flip()	

pygame.quit()

	



		
