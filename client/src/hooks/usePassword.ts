import { Password as PasswordApi } from '@/api';
import { IPassword } from '@/interfaces';
import { errorService } from '@/services/error.service';
import toast from 'react-hot-toast';

export default function usePassword() {
    const api: PasswordApi = new PasswordApi();

    const getAll = async () => {
        try {
            const response = await api.getAll();
            return response.data;
        } catch (error) {
            errorService.sendError(error);
        }
    };
    const getAllTypes = async () => {
        try {
            const response = await api.getAllTypes();
            return response.data;
        } catch (error) {
            errorService.sendError(error);
        }
    };
    const createPassword = async (createModel: IPassword) => {
        if (createModel.name.length > 0 || createModel.value.length > 0) {
            try {
                await api.create(createModel);
                toast.success('Успешно!');
                window.location.reload();
            } catch (error) {
                errorService.sendError(error);
            }
        } else {
            toast.error('Заполинте поле!');
        }
    };

    return {
        getAll,
        getAllTypes,
        createPassword,
    };
}
