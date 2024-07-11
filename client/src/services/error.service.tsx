import toast from 'react-hot-toast';

const sendError = (error: any) => {
    if (error) {
        toast.error(`${error.response.data.message}`);
    } else {
        toast.error('Не удалось обработать ошибку!');
    }
};

export const errorService = {
    sendError,
};
