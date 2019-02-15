 
 A = cellfun(@HogH,traindata,'UniformOutput',false);


c = length(traindata);
double_matrix = cell2mat(A');
alphab = ('A':'Z');
char_array = char(ones(c,1) * 'A');
for itr=1:26
    char_array(((itr-1) * (c/26)) + 1: ((itr-1) * (c/26)) + (c/26)) = alphab(itr);
end


t1 = num2cell(char_array);

Mdl = fitcknn(double_matrix,t1.');



