import { Constants } from '@/constants/';
import { IPassword } from '@/interfaces';
import api from './api';

export default class Password {
    getAll = async () => api.get(Constants.URL_API + `password/get-all`);
    getAllTypes = async () => api.get(Constants.URL_API + `password/get-all-types`);
    create = async (createModel: IPassword) =>
        api.post(Constants.URL_API + `password/create`, {
            name: createModel.name,
            value: createModel.value,
            passwordTypeId: createModel.passwordTypeId,
        });
}
