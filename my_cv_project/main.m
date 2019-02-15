
figure
subplot(1,4,1);
I = testdata{21};
imshow(I);
hog = HogH(I);
class = predict(Mdl,hog);
title(class);

subplot(1,4,2);
I = testdata{6000};
imshow(I);
hog = HogH(I);
class = predict(Mdl,hog);
title(class);

subplot(1,4,3);
I = testdata{4322};
imshow(I);
hog = HogH(I);
class = predict(Mdl,hog);
title(class);

subplot(1,4,4);
I = testdata{2312};
imshow(I);
hog = HogH(I);
class = predict(Mdl,hog);
title(class);