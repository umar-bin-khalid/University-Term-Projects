function [feature] = HogH(im)

if size(im,3)==3
    im=rgb2gray(im);
end
im=double(im);

rows=size(im,1);
cols=size(im,2);



[magnitude,angle] = imgradient(im,'central');
angle=imadd(angle,90);


feature=[];

for i = 1:8:rows-7
    for j=1:8:cols-7
        
        
    magA = magnitude(i : i+7 , j : j+7);
    angleA = angle(i : i+7 , j : j+7);
    histr  =zeros(1,9);
        
    for p=1:8
        for q=1:8
                          
            alpha= angleA(p,q);

            if alpha>0 && alpha<=20
            histr(1)=histr(1)+ magA(p,q)*(20-alpha)/20;
            histr(2)=histr(2)+ magA(p,q)*(alpha-0)/20;
            elseif alpha>20 && alpha<=40
            histr(2)=histr(2)+ magA(p,q)*(40-alpha)/20;                 
            histr(3)=histr(3)+ magA(p,q)*(alpha-20)/20;
            elseif alpha>40 && alpha<=60
            histr(3)=histr(3)+ magA(p,q)*(60-alpha)/20;
            histr(4)=histr(4)+ magA(p,q)*(alpha-40)/20;
            elseif alpha>60 && alpha<=80
            histr(4)=histr(4)+ magA(p,q)*(80-alpha)/20;
            histr(5)=histr(5)+ magA(p,q)*(alpha-60)/20;
            elseif alpha>80 && alpha<=100
            histr(5)=histr(5)+ magA(p,q)*(100-alpha)/20;
            histr(6)=histr(6)+ magA(p,q)*(alpha-80)/20;
            elseif alpha>100 && alpha<=120
            histr(6)=histr(6)+ magA(p,q)*(120-alpha)/20;
            histr(7)=histr(7)+ magA(p,q)*(alpha-100)/20;
            elseif alpha>120 && alpha<=140
            histr(7)=histr(7)+ magA(p,q)*(140-alpha)/20;
            histr(8)=histr(8)+ magA(p,q)*(alpha-120)/20;
            elseif alpha>140 && alpha<=160
            histr(8)=histr(8)+ magA(p,q)*(160-alpha)/20;
            histr(9)=histr(9)+ magA(p,q)*(alpha-140)/20;
            elseif alpha>=160 && alpha<=180
            histr(1)=histr(1)+ magA(p,q)*(alpha-160)/20;
            histr(9)=histr(9)+ magA(p,q)*(180-alpha)/20;
            elseif alpha>170 && alpha<=180
            histr(9)=histr(9)+ magA(p,q)*(190-alpha)/20;
            histr(1)=histr(1)+ magA(p,q)*(alpha-170)/20;
            end


        end
    end
    feature=[feature histr]; 
           
    end
end
end

        